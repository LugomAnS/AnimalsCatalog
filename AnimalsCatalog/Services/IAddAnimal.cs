using System;
using DataModels;

namespace AnimalsCatalog.Services
{
    internal interface IAddAnimal
    {
        public event Action<IAnimal>? AddNewAnimal;

        public void AddAnimal(IAnimal newAnimal);
    }
}
