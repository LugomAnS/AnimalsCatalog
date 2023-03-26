namespace DataModels.Models
{
    internal class Mammal : IAnimal
    {
        public int Id { get; set; }
        public string AnimalType { get; set; }
        public string? AnimalSubType { get; set ; }
        public string? Description { get; set; }

        public Mammal() { }

        public Mammal(string animalType, string animalSubType = null!, string description = null!) : this()
        {
            AnimalType = animalType;
            AnimalSubType = animalSubType;
            Description = description;
        }
    }
}
