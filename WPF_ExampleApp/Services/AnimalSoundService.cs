﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ExampleApp.Enums;
using WPF_ExampleApp.Events;
using WPF_ExampleApp.ServiceInterfaces;

namespace WPF_ExampleApp.Services
{
    public class AnimalSoundService : IAnimalSoundService
    {
        public event EventHandler<AnimalCallEventArgs> AnimalCalling;

        public string MakeAnimalSound()
        {
            return "Meow";
        }

        public void AnimalTypeCalling(int number)
        {
            AnimalCalling?.Invoke(this, new AnimalCallEventArgs((AnimalsEnum)number));
        }
    }
}
