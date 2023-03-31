using System;
using DataAccess;

namespace AnimalsCatalog.Services
{
    internal interface IDataProviderChange
    {
        public static event Action<IDataAccess> ProviderChange;
    }
}
