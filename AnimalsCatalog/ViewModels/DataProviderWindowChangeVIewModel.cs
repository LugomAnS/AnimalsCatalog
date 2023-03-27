using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsCatalog.Services;
using Infrastructure;

namespace AnimalsCatalog.ViewModels
{
    internal class DataProviderWindowChangeVIewModel : INPC
    {
        #region Fields and properties

        #region Data provider changer

        private readonly IDataProviderChanger _dataProviderChanger;

        #endregion

        #region selectedProvider: string - New provider choice

        ///<summary>New provider choice</summary>
        private string _selectedProvider;

        ///<summary>New provider choice</summary>
        public string SelectedProvider
        {
            get => _selectedProvider;
            set => Set(ref _selectedProvider, value);
        }

        #endregion

        #endregion

        public DataProviderWindowChangeVIewModel(IDataProviderChanger dataProviderChanger)
        {
            _dataProviderChanger = dataProviderChanger;
            
        }
    }
}
