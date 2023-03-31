using System.Collections.ObjectModel;
using System.Linq;
using DataModels;
using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using SQLDataProvider;

namespace DataAccess.Implementation
{
    public class SqlData : IDataAccess
    {
        private readonly SqlLiteDataContext _db;

        public SqlData(SqlLiteDataContext dataContext)
        {
            _db = dataContext;
            _db.Mammals.Load();
            _db.Amphibians.Load();
            _db.Birds.Load();
        }

        public void AddAnimal(IAnimal animal)
        {
            _db.Mammals.Add(animal as Mammal);
            _db.SaveChanges();
        }

        public void DeleteAnimal(IAnimal animal)
        {
          //  _db.Animals.Remove(animal);
            _db.SaveChanges();
        }

        public ObservableCollection<IAnimal> GetAllAnimalData()
        {
            ObservableCollection<IAnimal> allAnimals = new ObservableCollection<IAnimal>();

            foreach (var item in _db.Mammals.Local.ToObservableCollection())
            {
                allAnimals.Add(item);
            }

            ;

            return allAnimals;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
