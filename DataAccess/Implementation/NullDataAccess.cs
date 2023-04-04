using DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class NullDataAccess : IDataAccess
    {
        public void AddAnimal(IAnimal animal) {}

        public void DeleteAnimal(IAnimal animal) {}

        public ObservableCollection<IAnimal> GetAllAnimalData() => null!;

        public void SaveChanges() { }

    }
}
