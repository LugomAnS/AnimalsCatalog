using System;
using System.Windows.Controls;
using AnimalsCatalog.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalsCatalog.Services.Implementation
{
    internal class UserDialogImplementation : IUserDialog
    {
        private readonly IServiceProvider _serviceProvider;
        private MainWindow? _mainWindow;

        public UserDialogImplementation(IServiceProvider services)
        {
            _serviceProvider = services;
        }

        /// <summary>
        /// Programms main window openning
        /// </summary>
        public void OpenMainWindow()
        {
            if (_mainWindow != null)
            {
                _mainWindow.Show();
                return;
            }

            _mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            _mainWindow.Show();
        }

        public UserControl ChangeDataProvider()
        {
            return _serviceProvider.GetRequiredService<DataProviderWindowChange>();
        }
    }
}
