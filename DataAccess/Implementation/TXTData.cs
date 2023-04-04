using DataModels;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace DataAccess.Implementation
{
    public class TXTData : IDataAccess
    {
        private const string _dataPath = @"AnimalData.txt";
        private ObservableCollection<IAnimal> _allAnimals;

        private readonly IAnimalFactory _animalFactory;

        public TXTData(IAnimalFactory animalFactory)
        {
            _animalFactory = animalFactory;
            _allAnimals = new ObservableCollection<IAnimal>();

            if (!File.Exists(_dataPath))
            {
                using (File.Create(_dataPath))
                {

                }
            }

            ReadDataFromFile();
        }

        public void AddAnimal(IAnimal animal)
        {
            _allAnimals.Add(animal);
            WriteDataToFile();
        }

        public void DeleteAnimal(IAnimal animal)
        {
            _allAnimals.Remove(animal);
            WriteDataToFile();
        }

        public ObservableCollection<IAnimal> GetAllAnimalData()
        {
            return _allAnimals;
        }

        public void SaveChanges()
        {
            WriteDataToFile();
        }

        // чтение информации из файла
        private void ReadDataFromFile()
        {
            using (StreamReader sr = new StreamReader(_dataPath))
            {
                string dataFromFile;
                while ( (dataFromFile = sr.ReadLine()) != null)
                {
                    string[] readAnimal = dataFromFile.Split(";");
                    IAnimal animal = _animalFactory.GetNewAnimal(readAnimal[0],
                        readAnimal[1],
                        readAnimal[2]);
                    _allAnimals.Add(animal);
                }
            }
        }

        // запись информации в файл
        private void WriteDataToFile()
        {
            File.Delete(_dataPath);
            using (File.Create(_dataPath))
            {
                
            }
            using (StreamWriter sw = new StreamWriter(_dataPath))
            {
                foreach (var item in _allAnimals)
                {
                    StringBuilder sb = new StringBuilder().AppendJoin(";",
                        item.AnimalType, item.AnimalSubType, item.Description);

                    sw.WriteLine(sb.ToString());
                }
            }
        }
    }
}
