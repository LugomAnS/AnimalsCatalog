﻿using System.Windows.Input;
using AnimalsCatalog.Services;
using DataModels;
using Infrastructure;

namespace AnimalsCatalog.ViewModels
{
    internal class EditAnimalViewModel : INPC
    {
        #region Animal editor service

        private readonly IAnimalEditor _animalEditor;

        #endregion

        #region Close control service

        private readonly IUserControlClose? _userControlClose;

        #endregion

        #region AnimalToEdit: IAnimal - Animal to edit

        ///<summary>Animal to edit</summary>
        private IAnimal? _animalToEdit;

        #endregion

        #region Is values change

        private bool _isChanged = false;

        private bool IsChanged
        {
            get => _isChanged;
            set => Set(ref _isChanged, value);
        }

        #endregion

        #region animalType: string? - Animal primary type

        ///<summary>Animal primary type</summary>
        private string? _animalType;

        ///<summary>Animal primary type</summary>
        public string? AnimalType
        {
            get => _animalType;
            set => Set(ref _animalType, value);
        }

        #endregion

        #region subType: string? - Sub type to edit

        ///<summary>Sub type to edit</summary>
        private string? _subType;

        ///<summary>Sub type to edit</summary>
        public string? SubType
        {
            get => _subType;
            set
            {
                Set(ref _subType, value);
                IsChanged = true;
            }
        }

        #endregion

        #region description: string? - Animal description

        ///<summary>Animal description</summary>
        private string? _description;

        ///<summary>Animal description</summary>
        public string? Description
        {
            get => _description;
            set
            {
                Set(ref _description, value);
                IsChanged = true;
            }
        }

        #endregion

        public EditAnimalViewModel()
        {
            SaveAnimalChangesCommand =
                new Command(OnSaveAnimalChangesCommandExecute, CanSaveAnimalChangesCommandExecute);
            UndoChangesCommand = new Command(OnUndoChangesCommandExecute, CanUndoChangesCommandExecute);
            CloseControlCommand = new Command(OnCloseControlCommandExecute, CanCloseControlCommandExecute);
        }

        public EditAnimalViewModel(IAnimalEditor animalEditor,
                                   IUserControlClose userControlClose) : this()
        {
            _animalEditor = animalEditor;
            _animalEditor.AnimalChanging += AnimalToEditChanging;
            _userControlClose = userControlClose;
        }

        #region Change animal to edit

        private void AnimalToEditChanging(IAnimal? animal)
        {
            _animalToEdit = animal;
            AnimalType = _animalToEdit?.AnimalType;
            SubType = _animalToEdit?.AnimalSubType;
            Description = _animalToEdit?.Description;

            IsChanged = false;
        }
        #endregion


        #region Commands

        #region Save changes

        public ICommand SaveAnimalChangesCommand { get; }

        private void OnSaveAnimalChangesCommandExecute(object? p)
        {
            _animalToEdit.AnimalSubType = SubType;
            _animalToEdit.Description = Description;

            _animalEditor.SavingChanges();
            IsChanged = false;
        }

        private bool CanSaveAnimalChangesCommandExecute(object? p) => IsChanged && _animalToEdit != null;

        #endregion

        #region Undo changes

        public ICommand UndoChangesCommand { get; }

        private void OnUndoChangesCommandExecute(object? p)
        {
            SubType = _animalToEdit?.AnimalSubType;
            Description = _animalToEdit?.Description;

            IsChanged = false;
        }

        private bool CanUndoChangesCommandExecute(object? p) => IsChanged && _animalToEdit != null;

        #endregion

        #region Close control command
        public ICommand CloseControlCommand { get; }

        private void OnCloseControlCommandExecute(object? p)
        {
            _userControlClose?.UserControlCloseRequest();
        }

        private bool CanCloseControlCommandExecute(object? p) => true;

        #endregion

        #endregion
    }
}
