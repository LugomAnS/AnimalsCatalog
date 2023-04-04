using Infrastructure;

namespace DataModels.Models
{
    public class Bird : INPC, IAnimal
    {
        public int Id { get; set; }
        public string AnimalType { get; set; }
        private string? _animalSubType;
        public string? AnimalSubType { get => _animalSubType; set => Set(ref _animalSubType, value); }
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
