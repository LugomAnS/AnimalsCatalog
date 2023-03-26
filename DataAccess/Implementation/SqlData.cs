using System.Collections.ObjectModel;
using DataModels;
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
            _db.Animals.Load();
        }

        public void AddAnimal(IAnimal animal)
        {
            _db.Animals.Add(animal);
            _db.SaveChanges();
        }

        public void DeleteAnimal(IAnimal animal)
        {
            _db.Animals.Remove(animal);
            _db.SaveChanges();
        }

        public ObservableCollection<IAnimal> GetAllAnimalData()
        {
            return _db.Animals.Local.ToObservableCollection();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
