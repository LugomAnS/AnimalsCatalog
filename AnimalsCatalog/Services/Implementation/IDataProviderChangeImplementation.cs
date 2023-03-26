using DataAccess;
using System;

namespace AnimalsCatalog.Services.Implementation
{
    internal class DataProviderChangeImplementation : IDataProviderChange, IDataProviderChanger
    {
        private readonly IDataAccessFactory _dataAccessFactory;

        public event Action<IDataAccess>? ProviderChange;

        public DataProviderChangeImplementation(IDataAccessFactory dataAccessFactory)
        {
            _dataAccessFactory = dataAccessFactory;
        }

        public void ProviderChanging(string providerType)
        {
            var dataProvider = _dataAccessFactory.GetDataProvider(providerType);
            ProviderChange?.Invoke(dataProvider);
        }
    }
}
