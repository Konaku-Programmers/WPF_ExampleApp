using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ExampleApp.Models
{
    //Being based on the ObservableObject class means we can use the Set method you see in the properties here,
    // - this lets us update values in the UI outside of the ViewModel this is used in.
    public class MeowModel : ObservableObject
    {
        private double _timeToMeowing;
        private int _catNumber;

        public double TimeToMeowing
        {
            get { return _timeToMeowing; }
            set { Set("TimeToMeowing", ref _timeToMeowing, value); }
        }

        public int CatNumber
        {
            get { return _catNumber; }
            set { Set("CatNumber", ref _catNumber, value); }
        }
    }
}
