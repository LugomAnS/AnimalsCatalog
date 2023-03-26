namespace DataModels.Models
{
    internal class Mammal : IAnimal
    {
        private string _type;

        public string AnimalType { get; set; }
        public string? AnimalSubType { get; set ; }
        public string? Description { get; set; }

        public Mammal()
        {
            _type = typeof(Mammal).ToString();
        }

        public Mammal(string animalType, string animalSubType = null!, string description = null!) : this()
        {
            AnimalType = animalType;
            AnimalSubType = animalSubType;
            Description = description;
        }
    }
}
