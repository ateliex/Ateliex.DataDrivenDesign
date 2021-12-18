using Ateliex.Areas.Cadastro.Windows;
using Ateliex.Areas.Comercial.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ateliex
{
    public partial class MainWindow
    {
        public IServiceProvider ServiceProvider { get; }

        public MainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
        }

        private void CadastroDeModelosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var modelosWindow = ServiceProvider.GetRequiredService<ModeloWindow>();

            modelosWindow.Show();
        }

        private void PlanejamentoComercialMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var planosComerciaisForm = ServiceProvider.GetRequiredService<PlanoComercialWindow>();

            planosComerciaisForm.Show();
        }
    }
}
