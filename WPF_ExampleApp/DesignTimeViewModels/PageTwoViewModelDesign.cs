using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ExampleApp.Models;

namespace WPF_ExampleApp.DesignTimeViewModels
{
    public class PageTwoViewModelDesign : ViewModelBase
    {

        #region Fields

        public string AnimalType { get; set; }

        #endregion

        public PageTwoViewModelDesign()
        {
            AnimalType = "Dog";
        }

        #region Methods



        #endregion

    }
}
