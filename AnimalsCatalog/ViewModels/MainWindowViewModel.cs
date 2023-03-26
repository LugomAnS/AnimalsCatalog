using AnimalsCatalog.Services;
using DataModels;
using Infrastructure;

namespace AnimalsCatalog.ViewModels
{
    internal class MainWindowViewModel : INPC
    {
        #region Fields and Properties

        #region Title 
        /// <summary>Window title</summary>
        public string Title { get; set; }
        #endregion

        #region UserDialog Service

        private readonly IUserDialog? _userDialog;

        #endregion

        #region AnimalFactory service

        private readonly IAnimalFactory _animalFactory; 

        #endregion

        #endregion

        #region Constructors
        public MainWindowViewModel()
        {
            Title = "Программа учета животных";
        }

        public MainWindowViewModel(IUserDialog userDialog, IAnimalFactory animalFactory) : this()
        {
            _userDialog = userDialog;
            _animalFactory = animalFactory;
        }
        #endregion

    }
}
