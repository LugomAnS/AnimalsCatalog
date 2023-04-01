using System.Windows.Controls;
using DataModels;

namespace AnimalsCatalog.Services
{
    internal interface IUserDialog
    {
        public void OpenMainWindow();

        public UserControl ChangeDataProvider();

        public UserControl EditAnimalWindow();
    }
}
