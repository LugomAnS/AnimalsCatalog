using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public interface IAnimalFactory
    {
        public IAnimal GetNewAnimal(string animalType, string? animalSubtype = null, string? description = null);
    }
}
