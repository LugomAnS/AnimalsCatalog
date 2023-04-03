using System;
using DataAccess;
using DataAccess.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalsCatalog.Services.Implementation
{
    internal class DataAccessFactoryImplementation : IDataAccessFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DataAccessFactoryImplementation(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IDataAccess GetDataProvider(string provider)
            => provider switch
            {
                "SQL" => _serviceProvider.GetRequiredService<SqlData>(),
                "Text" => _serviceProvider.GetRequiredService<TXTData>(),
                _ => new NullDataAccess(),
            };
    }
}
