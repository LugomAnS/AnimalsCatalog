using System.Collections.ObjectModel;
using DataModels;

namespace DataAccess
{
    public interface IDataAccess
    {
        public void AddAnimal(IAnimal animal);
        public void DeleteAnimal(IAnimal animal);
        public void SaveChanges();
        public ObservableCollection<IAnimal> GetAllAnimalData();
    }
}
