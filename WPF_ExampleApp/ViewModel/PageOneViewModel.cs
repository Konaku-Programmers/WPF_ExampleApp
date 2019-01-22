using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WPF_ExampleApp.Models;

namespace WPF_ExampleApp.ViewModel
{
    public class PageOneViewModel : ViewModelBase
    {
        #region Service Fields

        IDialogCoordinator _dialogService;

        #endregion

        #region Fields

        private string _catLocation;
        private double _timeToMeowing;
        private ObservableCollection<MeowModel> _meowModels;
        private Timer _meowTimer;

        #endregion

        public PageOneViewModel(IDialogCoordinator dialogService)
        {
            _dialogService = dialogService;

            MeowModels = new ObservableCollection<MeowModel>();
            _meowTimer = new Timer(1000);

            _meowTimer.Elapsed += new ElapsedEventHandler(meowTimer_Elapsed);

            MeowCommand = new RelayCommand(Meow);
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

        /// <summary>
        /// An ObservableCollection is akin to a List however when members of this change, the UI will be updated about it and
        /// - adjust accordingly. Sometimes you may want to use a List as the field and return it as a new ObservableCollection,
        /// - I say this because ObservableCollection does not have access to a few Linq expressions that a List would.
        /// </summary>
        public ObservableCollection<MeowModel> MeowModels
        {
            get { return _meowModels; }
            set { _meowModels = value; RaisePropertyChanged(() => MeowModels); }
        }

        public string ComputerName
        {
            get { return Environment.MachineName; }
        }

        #endregion

        #region Methods

        private async void Meow()
        {
            int catNumber = 1;

            _timeToMeowing = 0;

            _meowTimer.Start();

            MessageDialogResult dialogResult = await _dialogService.ShowMessageAsync(this, "Meow?", "Meow me-ooow mew, meow?",
                                               MessageDialogStyle.AffirmativeAndNegative,
                                               new MetroDialogSettings() { NegativeButtonText = "Meow...", AffirmativeButtonText = "Meow!" });

            if (dialogResult == MessageDialogResult.Negative)
            {
                catNumber = 2;
            }

            CatLocation = $"/WPF_ExampleApp;component/Images/cat{catNumber}.jpg";

            _meowTimer.Stop();

            MeowModels.Add(new MeowModel
            {
                TimeToMeowing = _timeToMeowing,
                CatNumber = catNumber
            });
        }
        
        private void meowTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timeToMeowing++;
        }

        #endregion
    }
}
