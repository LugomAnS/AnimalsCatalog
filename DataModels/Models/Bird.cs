using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class Bird : IAnimal
    {
        public string AnimalType { get; set; }
        public string? AnimalSubType { get; set; }
        public string? Description { get; set; }

        public Bird() { }

        public Bird(string animalType, string animalSubType = null!, string description = null!) : this()
        {
            AnimalType = animalType;
            AnimalSubType = animalSubType;
            Description = description;
        }
    }
}
