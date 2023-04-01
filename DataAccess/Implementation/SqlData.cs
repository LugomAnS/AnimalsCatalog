using System.Collections.ObjectModel;
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
            if (animal is Mammal)
            {
                _db.Mammals.Add((Mammal)animal);
            }

            if (animal is Bird)
            {
                _db.Birds.Add((Bird)animal);
            }

            if (animal is Amphibian)
            {
                _db.Amphibians.Add((Amphibian)animal);
            }
            _db.SaveChanges();
        }

        public void DeleteAnimal(IAnimal animal)
        {
            if (animal is Mammal)
            {
                _db.Mammals.Remove((Mammal)animal);
            }

            if (animal is Bird)
            {
                _db.Birds.Remove((Bird)animal);
            }

            if (animal is Amphibian)
            {
                _db.Amphibians.Remove((Amphibian)animal);
            }
            _db.SaveChanges();
        }

        public ObservableCollection<IAnimal> GetAllAnimalData()
        {
            ObservableCollection<IAnimal> allAnimals = new ObservableCollection<IAnimal>();

            foreach (var item in _db.Mammals.Local.ToObservableCollection())
            {
                allAnimals.Add(item);
            }

            foreach (var item in _db.Birds.Local.ToObservableCollection())
            {
                allAnimals.Add(item);
            }

            foreach (var item in _db.Amphibians.Local.ToObservableCollection())
            {
                allAnimals.Add(item);
            }

            return allAnimals;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
