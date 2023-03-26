using System.Collections.ObjectModel;
using System.Windows.Input;
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

        #region ObservableCollection<IAnimal> - Animals collection

        ///<summary>Animals collection</summary>
        private ObservableCollection<IAnimal>? _animals = new ObservableCollection<IAnimal>();

        ///<summary>Animals collection</summary>
        public ObservableCollection<IAnimal>? Animals
        {
            get => _animals;
            set => Set(ref _animals, value);
        }

        #endregion

        #region SelectedAnimal: IAnimal - Selected animal

        ///<summary>Selected animal</summary>
        private IAnimal? _selectedAnimal;

        ///<summary>Selected animal</summary>
        public IAnimal? SelectedAnimal
        {
            get => _selectedAnimal;
            set => Set(ref _selectedAnimal,value);
        }

        #endregion

        #endregion

        #region Constructors
        public MainWindowViewModel()
        {
            Title = "Программа учета животных";

            AddMammalCommand = new Command(OnAddMammalCommandExecute, CanAddAnimalCommandExecute);
            AddBirdCommand = new Command(OnAddBirdCommandExecute, CanAddAnimalCommandExecute);
            AddAmphibianCommand = new Command(OnAddAmphibianCommandExecute, CanAddAnimalCommandExecute);
            DeleteAnimalCommand = new Command(OnDeleteAnimalCommandExecute, CanDeleteAnimalCommandExecute);
        }

        public MainWindowViewModel(IUserDialog userDialog, IAnimalFactory animalFactory) : this()
        {
            _userDialog = userDialog;
            _animalFactory = animalFactory;
        }
        #endregion

        #region Commands

        #region Check - can add animal
        private bool CanAddAnimalCommandExecute(object? p)
            => _animals != null;
        #endregion

        #region Add mammal command

        public ICommand AddMammalCommand { get; }

        private void OnAddMammalCommandExecute(object? p)
        {
            Animals?.Add(_animalFactory.GetNewAnimal("Млекопитающее"));
        }

        #endregion

        #region Add bird command
        public ICommand AddBirdCommand { get; }

        private void OnAddBirdCommandExecute(object? p)
        {
            Animals?.Add(_animalFactory.GetNewAnimal("Птица"));
        }

        #endregion

        #region Add amphibian command
        public ICommand AddAmphibianCommand { get; }

        private void OnAddAmphibianCommandExecute(object? p)
        {
            Animals?.Add(_animalFactory.GetNewAnimal("Земноводное"));
        }

        #endregion

        #region Delete animal
        public ICommand DeleteAnimalCommand { get; }

        private void OnDeleteAnimalCommandExecute(object? p)
        {
            Animals?.Remove(SelectedAnimal!);
        }

        private bool CanDeleteAnimalCommandExecute(object? p)
            => SelectedAnimal != null;

        #endregion

        #endregion
    }
}
