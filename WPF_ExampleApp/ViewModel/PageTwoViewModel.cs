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
    public class PageTwoViewModel : ViewModelBase
    {
        #region Service Fields

        IDialogCoordinator _dialogService;

        #endregion

        #region Fields

        #endregion

        public PageTwoViewModel(IDialogCoordinator dialogService)
        {
            _dialogService = dialogService;
        }

        #region Commands

        #endregion

        #region Properties

        #endregion

        #region Methods

        #endregion
    }
}
