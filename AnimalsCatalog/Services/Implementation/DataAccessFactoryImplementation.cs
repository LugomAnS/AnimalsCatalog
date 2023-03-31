using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Implementation
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
                "SQL" => _serviceProvider.GetRequiredService<IDataAccess>(),
                _ => new NullDataAccess(),
            };
    }
}
