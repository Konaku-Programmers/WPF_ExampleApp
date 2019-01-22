using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ExampleApp.DesignTimeViewModels
{
    public class PageOneViewModelDesign : ViewModelBase
    {

        #region Fields

        public string CatLocation;
        public string ComputerName;

        #endregion

        public PageOneViewModelDesign()
        {
            ComputerName = "Beep-Boop-PC";
        }

        #region Methods



        #endregion

    }
}
