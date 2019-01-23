using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ExampleApp.Enums;

namespace WPF_ExampleApp.Events
{
    public class AnimalCallEventArgs : EventArgs
    {
        public AnimalsEnum AnimalCall { get; set; }

        public AnimalCallEventArgs(AnimalsEnum animalCall)
        {
            AnimalCall = animalCall;
        }
    }
}
