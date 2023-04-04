using System;
using DataModels;

namespace AnimalsCatalog.Services
{
    internal interface IAnimalEditor
    {
        public event Action<IAnimal> AnimalChanging;

        public event Action? SaveChanges;

        public void ChangeAnimal(IAnimal animal);

        public void SavingChanges();
    }
}
