using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AnimalsCatalog.Services;
using DataModels;
using Infrastructure;

namespace AnimalsCatalog.ViewModels
{
    internal class AddAnimalViewModel : INPC
    {
        #region Fields and properties

        #region User control close service

        private readonly IUserControlClose? _userControlClose;

        #endregion

        #region Add new animal sevice

        private readonly IAddAnimal? _addAnimal;

        #endregion

        #region Animal factory

        private readonly IAnimalFactory? _animalFactory;

        #endregion

        #region animalType: string? - Animal type

        ///<summary>Animal type</summary>
        private string _animalType = "";

        ///<summary>Animal type</summary>
        public string AnimalType
        {
            get => _animalType;
            set => Set(ref _animalType, value);
        }

        #endregion

        #region animalSubtype: string? - Animal subtype

        ///<summary>Animal subtype</summary>
        private string? _animalSubtype;

        ///<summary>Animal subtype</summary>
        public string? AnimalSubtype
        {
            get => _animalSubtype;
            set => Set(ref _animalSubtype, value);
        }

        #endregion

        #region description: string? - Animal description

        ///<summary>Animal description</summary>
        private string? _description;

        ///<summary>Animal description</summary>
        public string? Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        #endregion

        #endregion

        #region Constructors

        public AddAnimalViewModel()
        {
            CloseControlCommand = new Command(OnCloseControlCommandExecute, CanCloseControlCommandExecute);
            AddNewAnimalCommand = new Command(OnAddNewAnimalCommandExecute, CanAddNewAnimalCommandExecute);
        }

        public AddAnimalViewModel(IUserControlClose userControlClose,
                                  IAddAnimal addAnimal,
                                  IAnimalFactory animalFactory) : this()
        {
            _userControlClose = userControlClose;
            _addAnimal = addAnimal;
            _animalFactory = animalFactory;
        }
        #endregion

        #region Commands

        #region Close control command
        public ICommand CloseControlCommand { get; }

        private void OnCloseControlCommandExecute(object? p)
        {
            _userControlClose?.UserControlCloseRequest();
        }

        private bool CanCloseControlCommandExecute(object? p) => true;

        #endregion

        #region Add animal command

        public ICommand AddNewAnimalCommand { get; }

        private void OnAddNewAnimalCommandExecute(object? p)
        {
            IAnimal animal = _animalFactory?.GetNewAnimal(AnimalType, AnimalSubtype!, Description!);
            _addAnimal.AddAnimal(animal);
        }

        private bool CanAddNewAnimalCommandExecute(object? p)
            => AnimalType.All(c => Char.IsLetter(c)) && !String.IsNullOrWhiteSpace(AnimalType);

        #endregion

        #endregion

    }
}
