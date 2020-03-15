using Ateliex.Collections;
using System.Windows;
using System.Windows.Data;

namespace Ateliex.Windows
{
    /// <summary>
    /// Interaction logic for ModelosWindow.xaml
    /// </summary>
    public partial class ModelosWindow
    {
        private readonly ModelosCollection modelosCollection;

        public ModelosWindow(ModelosCollection modelosCollection)
        {
            this.modelosCollection = modelosCollection;

            modelosCollection.StatusChanged += SetStatusBar;

            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var modelos = await modelosCollection.ObtemModelosAsync();

            //var list = modelos.Select(p => ModeloViewModel.From(p)).ToList();

            //var observableCollection = new ModelosCollection(
            //    modelosLocalService,
            //    //consultaDeModelos,
            //    //planejamentoComercial,
            //    list
            //);

            //modelosBindingSource.DataSource = bindingList;            

            CollectionViewSource modelosViewSource = ((CollectionViewSource)(this.FindResource("modelosViewSource")));

            modelosViewSource.Source = modelosCollection;

            await modelosCollection.Load();
        }

        private void SetStatusBar(string value)
        {
            statusBarLabel.Content = value;

            //statusBarTimer.Enabled = true;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //CollectionViewSource modelosViewSource = ((CollectionViewSource)(this.FindResource("modelosViewSource")));

            //var observableCollection = (ModelosCollection)modelosViewSource.Source;

            await modelosCollection.SaveChanges();
        }

        private void AdicionarModeloButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    //public class ModeloValidationRule : ValidationRule
    //{
    //    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
    //    {
    //        ModeloViewModel viewModel = (value as BindingGroup).Items[0] as ModeloViewModel;

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
}
