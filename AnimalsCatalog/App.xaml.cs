using System;
using System.Windows;
using AnimalsCatalog.Services;
using AnimalsCatalog.Services.Implementation;
using AnimalsCatalog.ViewModels;
using AnimalsCatalog.Views;
using DataAccess;
using DataAccess.Implementation;
using DataModels;
using DataModels.Implementation;
using Microsoft.Extensions.DependencyInjection;
using SQLDataProvider;

namespace AnimalsCatalog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private static IServiceProvider? _serviceProvider;

        public static IServiceProvider ServiceProvider
        {
            get
            {
                _serviceProvider = InitServiceCollection().BuildServiceProvider();
                return _serviceProvider;
            }
        }

        private static IServiceCollection InitServiceCollection()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IUserDialog, UserDialogImplementation>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddTransient<IAnimalFactory, AnimalFactory>();
            services.AddSingleton<IDataAccess, SqlData>();
            services.AddSingleton<SqlLiteDataContext>();
            services.AddSingleton<DataProviderWindowChangeVIewModel>();

            // MainWindow
            services.AddSingleton(s =>
            {
                var model = s.GetRequiredService<MainWindowViewModel>();
                var window = new MainWindow { DataContext = model };
                return window;
            });

            // Change data provider window
            services.AddTransient(s =>
            {
                var model = s.GetRequiredService<DataProviderWindowChangeVIewModel>();
                var window = new DataProviderWindowChange { DataContext = model };
                return window;
            });
            

            return services;
        }

        #region Overrides of Application

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServiceProvider.GetService<IUserDialog>()?.OpenMainWindow();
        }

        #endregion
    }
}
