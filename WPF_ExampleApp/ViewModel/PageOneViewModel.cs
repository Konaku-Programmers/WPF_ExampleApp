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
using WPF_ExampleApp.Enums;
using WPF_ExampleApp.Events;
using WPF_ExampleApp.Models;
using WPF_ExampleApp.ServiceInterfaces;

namespace WPF_ExampleApp.ViewModel
{
    public class PageOneViewModel : ViewModelBase
    {
        #region Service Fields

        private IDialogCoordinator _dialogService;
        private IAnimalSoundService _animalSoundService;

        #endregion

        #region Fields

        private string _catLocation;
        private double _timeToMeowing;
        private ObservableCollection<MeowModel> _meowModels;
        private Timer _meowTimer;
        private Random _randomNumber;

        #endregion

        public PageOneViewModel(IDialogCoordinator dialogService, IAnimalSoundService animalSoundService)
        {
            _dialogService = dialogService;
            _animalSoundService = animalSoundService;

            MeowModels = new ObservableCollection<MeowModel>();
            _meowTimer = new Timer(1000);
            _randomNumber = new Random();

            _meowTimer.Elapsed += new ElapsedEventHandler(_meowTimer_Elapsed);

            MeowCommand = new RelayCommand(Meow);
            RandomNumberCommand = new RelayCommand<object>(RandomNumberGenerate);
        }

        #region Commands

        public RelayCommand MeowCommand { get; private set; }
        public RelayCommand<object> RandomNumberCommand { get; private set; }

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

            MessageDialogResult dialogResult = await _dialogService.ShowMessageAsync(this, "Meow?", "Meow me-ooow mew, meow?",
                                               MessageDialogStyle.AffirmativeAndNegative,
                                               new MetroDialogSettings() { NegativeButtonText = $"{_animalSoundService.MakeAnimalSound()}...", AffirmativeButtonText = $"{_animalSoundService.MakeAnimalSound()}!" });

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

            _timeToMeowing = 0;

            _meowTimer.Start();
        }

        private void RandomNumberGenerate(object rowItem)
        {
            MeowModel meowModel = rowItem as MeowModel;

            meowModel.RandomNumber = _randomNumber.Next(0, 5);

            _animalSoundService.AnimalTypeCalling(meowModel.RandomNumber);
        }

        #endregion

        #region Events

        private void _meowTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timeToMeowing++;
        }

        #endregion
    }
}
