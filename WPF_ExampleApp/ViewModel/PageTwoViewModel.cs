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
using WPF_ExampleApp.Events;
using WPF_ExampleApp.Models;
using WPF_ExampleApp.ServiceInterfaces;

namespace WPF_ExampleApp.ViewModel
{
    public class PageTwoViewModel : ViewModelBase
    {
        #region Service Fields

        private IAnimalSoundService _animalSoundService;

        #endregion

        #region Fields

        private string _animalType;

        #endregion

        public PageTwoViewModel(IAnimalSoundService animalSoundService)
        {
            _animalSoundService = animalSoundService;

            _animalSoundService.AnimalCalling += _animalSoundService_AnimalCalling;
        }

        #region Commands

        #endregion

        #region Properties

        public string AnimalType
        {
            get { return _animalType; }
            set { _animalType = value; RaisePropertyChanged(() => AnimalType); }
        }

        #endregion

        #region Methods

        #endregion

        #region Events

        private void _animalSoundService_AnimalCalling(object sender, AnimalCallEventArgs e)
        {
            AnimalType = e.AnimalCall.ToString();
        }

        #endregion
    }
}
