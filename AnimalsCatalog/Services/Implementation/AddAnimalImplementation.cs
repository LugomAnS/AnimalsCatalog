using DataModels;
using System;

namespace AnimalsCatalog.Services.Implementation
{
    internal class AddAnimalImplementation : IAddAnimal
    {
        public event Action<IAnimal>? AddNewAnimal;

        public void AddAnimal(IAnimal newAnimal)
        {
            AddNewAnimal?.Invoke(newAnimal);
        }
    }
}
