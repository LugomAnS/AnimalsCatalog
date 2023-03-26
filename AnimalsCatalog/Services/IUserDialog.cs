using System.Windows.Controls;
using DataAccess;

namespace AnimalsCatalog.Services
{
    internal interface IUserDialog
    {
        public void OpenMainWindow();

        public UserControl ChangeDataProvider();
    }
}
