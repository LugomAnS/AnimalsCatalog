﻿using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using AnimalsCatalog.Services;
using DataAccess;
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

        private readonly IUserDialog _userDialog;

        #endregion

        #region AnimalFactory service

        private readonly IAnimalFactory _animalFactory;

        #endregion

        #region Provider changing service

        private readonly IDataProviderChange _providerChange;

        #endregion

        #region Data access source

        private IDataAccess? _dataAccess = null;

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
            set => Set(ref _selectedAnimal,value);
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
        }

        public MainWindowViewModel(IUserDialog userDialog, 
                                   IAnimalFactory animalFactory,
                                   IDataProviderChange providerChange) : this()
        {
            _userDialog = userDialog;
            _animalFactory = animalFactory;
            _providerChange = providerChange;
            _providerChange.ProviderChange += OnProviderChange;

        }
        #endregion

        #region Provider change

        private void OnProviderChange(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
            Animals = DataAccess?.GetAllAnimalData();
            UserWorkControl = null;
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
            //Animals?.Add(_animalFactory.GetNewAnimal("Млекопитающее"));
            DataAccess!.AddAnimal(_animalFactory.GetNewAnimal("Млекопитающее"));
        }

        #endregion

        #region Add bird command
        public ICommand AddBirdCommand { get; }

        private void OnAddBirdCommandExecute(object? p)
        {
            //Animals?.Add(_animalFactory.GetNewAnimal("Птица"));
            DataAccess!.AddAnimal(_animalFactory.GetNewAnimal("Птица"));
        }

        #endregion

        #region Add amphibian command
        public ICommand AddAmphibianCommand { get; }

        private void OnAddAmphibianCommandExecute(object? p)
        {
            //Animals?.Add(_animalFactory.GetNewAnimal("Земноводное"));
            DataAccess!.AddAnimal(_animalFactory.GetNewAnimal("Земноводное"));
        }

        #endregion

        #region Delete animal
        public ICommand DeleteAnimalCommand { get; }

        private void OnDeleteAnimalCommandExecute(object? p)
        {
            //Animals?.Remove(SelectedAnimal!);
            DataAccess!.DeleteAnimal(SelectedAnimal!);
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

        #endregion
    }
}
