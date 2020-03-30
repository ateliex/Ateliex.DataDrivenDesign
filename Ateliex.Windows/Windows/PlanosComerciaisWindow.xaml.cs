using Ateliex.Models;
using Ateliex.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ateliex.Windows
{
    /// <summary>
    /// Interaction logic for PlanosComerciaisWindow.xaml
    /// </summary>
    public partial class PlanosComerciaisWindow
    {
        private readonly PlanosComerciaisInfraService planosComerciaisInfraService;

        private readonly ModelosInfraService modelosInfraService;

        public PlanosComerciaisWindow(
            PlanosComerciaisInfraService planosComerciaisInfraService,
            ModelosInfraService modelosInfraService
        )
        {
            this.planosComerciaisInfraService = planosComerciaisInfraService;

            this.modelosInfraService = modelosInfraService;

            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CollectionViewSource planosComerciaisViewSource = ((CollectionViewSource)(this.FindResource("planosComerciaisViewSource")));

            var modelos = await planosComerciaisInfraService.ObtemPlanosComerciaisAsync();

            planosComerciaisViewSource.Source = modelos;
        }

        //void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        //{
        //    e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        //}

        private void SetStatusBar(string value)
        {
            statusBarLabel.Content = value;

            //statusBarTimer.Enabled = true;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //CollectionViewSource planosComerciaisViewSource = ((CollectionViewSource)(this.FindResource("planosComerciaisViewSource")));

            //var observableCollection = (PlanosComerciaisObservableCollection)planosComerciaisViewSource.Source;

            try
            {
                await planosComerciaisInfraService.SaveChangesAsync();

                SetStatusBar("Modelos salvos com sucesso.");
            }
            catch (Exception ex)
            {
                SetStatusBar(ex.Message);
            }
        }

        private void AdicionarModeloButton_Click(object sender, RoutedEventArgs e)
        {
            if (planosComerciaisDataGrid.CurrentItem == null) return;

            var consultaDeModelosWindow = new ConsultaDeModelosWindow(
                modelosInfraService
            );

            var selecteds = GetSelectedItens();

            consultaDeModelosWindow.SetSelecteds(selecteds);

            consultaDeModelosWindow.ShowDialog();

            var planoComercial = planosComerciaisDataGrid.CurrentItem as PlanoComercial;

            var modelos = consultaDeModelosWindow.GetSelecteds();

            foreach (var modelo in modelos)
            {
                if (!planoComercial.Itens.Any(item => item.Modelo.Codigo == modelo.Codigo))
                {
                    var model = planoComercial.AdicionaItem(modelo);

                    //var viewModel = ItemDePlanoComercial.From(model, repositorioDePlanosComerciais, repositorioDeModelos);

                    //viewModel.itemDePlanoComercial = model;

                    planoComercial.Itens.Add(model);
                }
            }
        }

        private IEnumerable<Modelo> GetSelectedItens()
        {
            var list = new List<Modelo>();

            foreach (var item in itensDataGrid.Items)
            {
                var viewModel = item as ItemDePlanoComercial;

                list.Add(viewModel.Modelo);
            }

            return list;
        }
    }

    //public class PlanoComercialValidationRule : ValidationRule
    //{
    //    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
    //    {
    //        PlanoComercial viewModel = (value as BindingGroup).Items[0] as PlanoComercial;

    //        if (viewModel.HasErrors)
    //        {
    //            return new ValidationResult(false, viewModel.Error);
    //        }
    //        else
    //        {
    //            return ValidationResult.ValidResult;
    //        }
    //    }
    //}

    public class ConvertItemToIndex : IValueConverter
    {
        #region IValueConverter Members
        //Convert the Item to an Index
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                DataGridRow row = value as DataGridRow;
                if (row == null)
                    throw new InvalidOperationException($"This converter class can only be used with DataGridRow elements. {value}");

                return row.GetIndex() + 1;

                //CollectionView cv = (CollectionView)dg.Items;
                ////Get the CollectionView from the DataGrid that is using the converter
                //DataGrid dg = (DataGrid)Application.Current.MainWindow.FindName("planosComerciaisDataGrid");
                ////Get the index of the item from the CollectionView
                //int rowindex = cv.IndexOf(value) + 1;

                //return rowindex.ToString();
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
        //One way binding, so ConvertBack is not implemented
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
