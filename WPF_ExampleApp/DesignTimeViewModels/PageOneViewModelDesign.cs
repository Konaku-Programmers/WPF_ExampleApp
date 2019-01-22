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
    public class PageOneViewModelDesign : ViewModelBase
    {

        #region Fields

        public string CatLocation;
        public string ComputerName;
        public ObservableCollection<MeowModel> MeowModels;

        #endregion

        public PageOneViewModelDesign()
        {
            ComputerName = "Beep-Boop-PC";

            MeowModels = new ObservableCollection<MeowModel>();

            for(int x = 0; x < 10; x++)
            {
                MeowModels.Add(new MeowModel
                {
                    CatNumber = x,
                    TimeToMeowing = x * x
                });
            }
        }

        #region Methods



        #endregion

    }
}
