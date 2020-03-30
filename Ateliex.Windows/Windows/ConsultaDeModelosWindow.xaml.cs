using Ateliex.Models;
using Ateliex.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Ateliex.Windows
{
    /// <summary>
    /// Interaction logic for ConsultaDeModelosWindow.xaml
    /// </summary>
    public partial class ConsultaDeModelosWindow : Window
    {
        private readonly ModelosInfraService modelosInfraService;

        public ConsultaDeModelosWindow(ModelosInfraService modelosInfraService)
        {
            this.modelosInfraService = modelosInfraService;

            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var modelos = await modelosInfraService.ObtemModelosAsync();

            var list = modelos.Select(p => ItemDeConsultaDeModeloViewModel.From(p, selecteds)).ToList();

            CollectionViewSource modelosViewSource = ((CollectionViewSource)(this.FindResource("modelosViewSource")));

            modelosViewSource.Source = list;
        }

        private IEnumerable<Modelo> selecteds;

        public void SetSelecteds(IEnumerable<Modelo> selecteds)
        {
            this.selecteds = selecteds;
        }

        public IEnumerable<Modelo> GetSelecteds()
        {
            var list = new List<Modelo>();

            foreach (var item in modelosDataGrid.Items)
            {
                var viewModel = item as ItemDeConsultaDeModeloViewModel;

                if (viewModel.Selected)
                {
                    list.Add(viewModel.Modelo);
                }
            }

            return list;
        }
    }

    public class ItemDeConsultaDeModeloViewModel
    {
        public bool Selected { get; set; }

        public Modelo Modelo { get; set; }

        public static ItemDeConsultaDeModeloViewModel From(Modelo modelo, IEnumerable<Modelo> selecteds)
        {
            var selected = selecteds.Any(p => p.Codigo == modelo.Codigo);

            var viewModel = new ItemDeConsultaDeModeloViewModel
            {
                Selected = selected,
                Modelo = modelo,
            };

            return viewModel;
        }
    }
}
