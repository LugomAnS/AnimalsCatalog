using System;
using DataAccess;

namespace AnimalsCatalog.Services
{
    internal interface IDataProviderChange
    {
        public event Action<IDataAccess> ProviderChange;
    }
}
