using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ExampleApp.ViewModel
{
    public class PageOneViewModel : ViewModelBase
    {
        #region Service Fields

        IDialogCoordinator _dialogService;

        #endregion

        #region Fields

        private string _catLocation;

        #endregion

        public PageOneViewModel(IDialogCoordinator dialogService)
        {
            _dialogService = dialogService;

            MeowCommand = new RelayCommand(Meow, CanMeow);
        }

        #region Commands

        public RelayCommand MeowCommand { get; private set; }

        #endregion

        #region Properties

        public string CatLocation
        {
            get { return _catLocation; }
            set { _catLocation = value; RaisePropertyChanged(() => CatLocation); }
        }

        public string ComputerName
        {
            get { return Environment.MachineName; }
        }

        #endregion

        #region Methods

        private bool CanMeow()
        {
            Task.Delay(2000);

            return true;
        }

        private async void Meow()
        {
            MessageDialogResult dialogResult = await _dialogService.ShowMessageAsync(this, "Meow?", "Do you meow?", 
                                            MessageDialogStyle.AffirmativeAndNegative, 
                                            new MetroDialogSettings() { NegativeButtonText = "Refuse", AffirmativeButtonText = "Meow" });

            if (dialogResult == MessageDialogResult.Affirmative)
            {
                CatLocation = "/WPF_ExampleApp;component/Images/cat1.jpg";
            }
            else
            {
                CatLocation = "/WPF_ExampleApp;component/Images/cat2.jpg";
            }
        }

        #endregion
    }
}
