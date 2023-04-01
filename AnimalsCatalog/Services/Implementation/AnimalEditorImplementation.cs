using System;
using DataModels;

namespace AnimalsCatalog.Services.Implementation
{
    internal class AnimalEditorImplementation : IAnimalEditor
    {

        public event Action<IAnimal>? AnimalChanging;
        public event Action? SaveChanges;

        public void ChangeAnimal(IAnimal animal)
        {
            AnimalChanging?.Invoke(animal);
        }

        public void SavingChanges()
        {
            SaveChanges?.Invoke();
        }
    }
}
