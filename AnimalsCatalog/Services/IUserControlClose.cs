using System;

namespace AnimalsCatalog.Services
{
    internal interface IUserControlClose
    {
        public event Action? UserControlClose;

        public void UserControlCloseRequest();
    }
}
