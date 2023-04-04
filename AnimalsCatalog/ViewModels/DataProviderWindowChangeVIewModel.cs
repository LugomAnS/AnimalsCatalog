using AnimalsCatalog.Services;
using Infrastructure;
using System.Windows.Input;

namespace AnimalsCatalog.ViewModels
{
    internal class DataProviderWindowChangeVIewModel : INPC
    {
        #region Fields and properties

        #region Data provider changer

        private readonly IDataProviderChanger _dataProviderChanger;

        #endregion

        #region Control close

        private IUserControlClose? _userControlClose;

        #endregion

        private string? _providerChoice = null;

        #endregion

        #region Constructors

        public DataProviderWindowChangeVIewModel(IDataProviderChanger dataProviderChanger,
            IUserControlClose userControlControlClose) : this()
        {
            _dataProviderChanger = dataProviderChanger;
            _userControlClose = userControlControlClose;

        }

        public DataProviderWindowChangeVIewModel()
        {
            ProviderSelectionCommand = new Command(OnProviderSelectionCommandExecute, CanProviderSelectionCommandExecute);
            ApplyProviderChoiceCommand = new Command(OnApplyProviderChoiceCommandExecute,
                CanApplyProviderChoiceCommandExecute);
            CloseControlCommand = new Command(OnCloseControlCommandCommand, CanCloseControlCommandExecute);
        }

        #endregion

        #region Commands

        #region Provider radio button selection

        public ICommand ProviderSelectionCommand { get; }

        private void OnProviderSelectionCommandExecute(object? p)
        {
            _providerChoice = p as string;
        }

        private bool CanProviderSelectionCommandExecute(object? p) => true;

        #endregion

        #region Apply provider choice
        public  ICommand ApplyProviderChoiceCommand { get; }

        private void OnApplyProviderChoiceCommandExecute(object? p)
        {
            _dataProviderChanger.ProviderChanging(_providerChoice!);
        }

        private bool CanApplyProviderChoiceCommandExecute(object? p)
            => _providerChoice != null;

        #endregion

        #region Close control command

        public ICommand CloseControlCommand { get; }

        private void OnCloseControlCommandCommand(object? p)
        {
            _userControlClose?.UserControlCloseRequest();
        }
        private bool CanCloseControlCommandExecute(object? p) => true;

        #endregion

        #endregion

    }
}
