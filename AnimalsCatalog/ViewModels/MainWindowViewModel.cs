using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AnimalsCatalog.Services;
using AnimalsCatalog.Services.Implementation;
using DataAccess;
using DataAccess.Implementation;
using DataModels;
using DataModels.Models;
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

        private readonly IAnimalFactory? _animalFactory;

        #endregion

        #region Edit animal service

        private IAnimalEditor _animalEditor;

        #endregion

        #region Data access source

        private IDataAccess? _dataAccess;

        public IDataAccess? DataAccess
        {
            get => _dataAccess;
            set => Set(ref _dataAccess, value);
        }

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
            set
            {
                Set(ref _selectedAnimal, value);
                _animalEditor.ChangeAnimal(_selectedAnimal!);
            }
        }

        #endregion

        #region Custom User control

        #region userWorkControl: UserControl - Control for different user works

        ///<summary>Control for different user works</summary>
        private UserControl? _userWorkControl;

        ///<summary>Control for different user works</summary>
        public UserControl? UserWorkControl
        {
            get => _userWorkControl;
            set => Set(ref _userWorkControl, value);
        }

        #endregion

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
            ChangeProviderWindowCommand = new Command(OnChangeProviderWindowCommandExecute);
            EditAnimalCommand = new Command(OnEditAnimalCommandExecute, CanEditAnimalCommandExecute);
            AddAnimalCommand = new Command(OnAddAnimalCommandExecute, CanAddAnimalCommandExecute);
        }

        public MainWindowViewModel(IUserDialog userDialog, 
                                   IAnimalFactory animalFactory,
                                   IAnimalEditor animalEditor,
                                   IUserControlClose userControlClose,
                                   IAddAnimal addAnimal) : this()
        {
            _userDialog = userDialog;
            _animalFactory = animalFactory;
            _animalEditor = animalEditor;
            _animalEditor.SaveChanges += SavechangesToDb;
            userControlClose.UserControlClose += CloseUserControl;
            addAnimal.AddNewAnimal += AddUserAnimal;

            DataProviderChangeImplementation.ProviderChange += OnProviderChange;

        }
        #endregion

        #region Provider change

        private void OnProviderChange(IDataAccess dataAccess)
        {
            if (dataAccess is NullDataAccess)
            {
                MessageBox.Show("Ошибка подключения к базе данных", "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            DataAccess = dataAccess;
            Animals = DataAccess?.GetAllAnimalData();
            UserWorkControl = null;
        }

        #endregion

        #region Save changes to db

        private void SavechangesToDb()
        {
            _dataAccess?.SaveChanges();
        }

        #endregion

        #region Control closing

        private void CloseUserControl()
        {
            UserWorkControl = null;
        }

        #endregion

        #region Add new animal

        private void AddUserAnimal(IAnimal animal)
        {
            if (animal is NullAnimal)
            {
                MessageBox.Show("Ошибка добавления животного, тип может быть " +
                                "только: Млекопитающее, Земноводное, Птица", "Ошибка", MessageBoxButton.OK);
                return;
            }

            DataAccess.AddAnimal(animal);
            Animals = DataAccess.GetAllAnimalData();
        }

        #endregion

        #region Commands

        #region Check - can add animal
        private bool CanAddAnimalCommandExecute(object? p)
            => Animals != null && DataAccess != null;
        #endregion

        #region Add mammal command

        public ICommand AddMammalCommand { get; }

        private void OnAddMammalCommandExecute(object? p)
        {
            DataAccess!.AddAnimal(_animalFactory.GetNewAnimal("Млекопитающее"));
            Animals = DataAccess.GetAllAnimalData();
        }

        #endregion

        #region Add bird command
        public ICommand AddBirdCommand { get; }

        private void OnAddBirdCommandExecute(object? p)
        {
            DataAccess!.AddAnimal(_animalFactory.GetNewAnimal("Птица"));
            Animals = DataAccess.GetAllAnimalData();
        }

        #endregion

        #region Add amphibian command
        public ICommand AddAmphibianCommand { get; }

        private void OnAddAmphibianCommandExecute(object? p)
        {
            DataAccess!.AddAnimal(_animalFactory.GetNewAnimal("Земноводное"));
            Animals = DataAccess.GetAllAnimalData();
        }

        #endregion

        #region Delete animal
        public ICommand DeleteAnimalCommand { get; }

        private void OnDeleteAnimalCommandExecute(object? p)
        {
            DataAccess!.DeleteAnimal(SelectedAnimal!);
            Animals = DataAccess.GetAllAnimalData();
        }

        private bool CanDeleteAnimalCommandExecute(object? p)
            => SelectedAnimal != null;

        #endregion

        #region Change data provider window
        public ICommand ChangeProviderWindowCommand { get; }

        private void OnChangeProviderWindowCommandExecute(object? p)
        {
            UserWorkControl = _userDialog.ChangeDataProvider();
        }


        #endregion

        #region Edit animal record window
        public ICommand EditAnimalCommand { get; }

        private void OnEditAnimalCommandExecute(object? p)
        {
            UserWorkControl = _userDialog.EditAnimalWindow();
            _animalEditor.ChangeAnimal(_selectedAnimal!);
        }

        private bool CanEditAnimalCommandExecute(object? p)
            => p != null;

        #endregion

        #region Add animal window

        public ICommand AddAnimalCommand { get; }

        private void OnAddAnimalCommandExecute(object? p)
        {
            UserWorkControl = _userDialog?.AddAnimalWindow();
        }

        #endregion

        #endregion
    }
}
