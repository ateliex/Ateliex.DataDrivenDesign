using Ateliex.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Ateliex.Areas.Cadastro.Models;

namespace Ateliex.Areas.Cadastro.Windows
{
    public partial class ModeloConsultaWindow : Window
    {
        private readonly AteliexDbContext db;

        public ModeloConsultaWindow(AteliexDbContext db)
        {
            this.db = db;

            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var modelos = await ObtemModelosAsync();

            var list = modelos.Select(p => ItemDeConsultaDeModeloViewModel.From(p, selecteds)).ToList();

            CollectionViewSource modelosViewSource = ((CollectionViewSource)(this.FindResource("modelosViewSource")));

            modelosViewSource.Source = modelos;
        }

        public async Task<Modelo[]> ObtemModelosAsync()
        {
            try
            {
                var modelos = await db.ModeloSet
                    .Include(p => p.Recursos)
                    .ToArrayAsync();

                //var observable = modelos.ToObservable();

                return modelos;
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException("Erro ao obter modelos.", ex);
            }
        }

        private IEnumerable<Modelo> selecteds;

        public void SetSelecteds(IEnumerable<Modelo> selecteds)
        {
            this.selecteds = selecteds;
        }

        public IEnumerable<Modelo> GetSelecteds()
        {
            //var x = modelosDataGrid.SelectedItems

            var list = new List<Modelo>();

            foreach (var item in modelosListView.SelectedItems)
            {
                var viewModel = item as Modelo;

                //if (viewModel.Selected)
                //{
                    list.Add(viewModel);
                //}
            }

            return list;
        }

        private void modelosListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

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
