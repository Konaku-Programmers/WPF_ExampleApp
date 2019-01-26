using System;
using WPF_ExampleApp.Events;

namespace WPF_ExampleApp.ServiceInterfaces
{
    public interface IAnimalSoundService
    {
        event EventHandler<AnimalCallEventArgs> AnimalCalling;

        string MakeAnimalSound();

        void AnimalTypeCalling(int number);
    }
}