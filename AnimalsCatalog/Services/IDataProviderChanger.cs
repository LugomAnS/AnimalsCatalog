using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsCatalog.Services
{
    public interface IDataProviderChanger
    {
        public void ProviderChanging(string providerType);
    }
}
