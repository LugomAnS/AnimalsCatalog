using System;

namespace AnimalsCatalog.Services.Implementation
{
    internal class UserControlCloseImplementation : IUserControlClose
    {
        public event Action? UserControlClose;

        public void UserControlCloseRequest()
        {
            UserControlClose?.Invoke();
        }
    }
}
