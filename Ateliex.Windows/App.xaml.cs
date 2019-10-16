using Ateliex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Ateliex
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var culture = CultureInfo.CreateSpecificCulture("pt-BR");

            Thread.CurrentThread.CurrentCulture = culture;

            Thread.CurrentThread.CurrentUICulture = culture;

            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            InitializeDatabase();
        }

        //private void ConfigureServices(IServiceCollection services)
        //{
        //    //services.AddDbContext<AteliexDbContext>(options =>
        //    //    //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        //    //    options.UseSqlite(@"Data Source=Ateliex.db"));

        //    //services.AddTransient(typeof(MainWindow));

        //    //services.AddTransient(typeof(ModelosLocalService));

        //    //services.AddTransient(typeof(ModelosDbService));

        //    //services.AddTransient(typeof(ModelosWindow));

        //    //services.AddTransient(typeof(ConsultaDeModelosWindow));

        //    //services.AddTransient(typeof(PlanosComerciaisWindow));

        //    //services.AddTransient(typeof(PlanosComerciaisLocalService));

        //    //services.AddTransient(typeof(PlanosComerciaisDbService));
        //}

        //private void InitializeContainer()
        //{
        //    var package = new InfrastructurePackage();

        //    var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        //    //container.RegisterPackages(assemblies);

        //    //container.Verify();
        //}

        private void InitializeDatabase()
        {
            using (var dbContext = new AteliexDbContext())
            {
                dbContext.Database.EnsureCreated();

                dbContext.Database.Migrate();
            }
        }
    }
}
