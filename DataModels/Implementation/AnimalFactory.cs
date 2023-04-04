using DataModels.Models;

namespace DataModels.Implementation
{
    public class AnimalFactory : IAnimalFactory
    {
        public AnimalFactory() {}

        public IAnimal GetNewAnimal(string animalType, string? animalSubtype = null, string? description = null)
        => animalType switch
            {
                "Млекопитающее" => new Mammal(animalType, animalSubtype!, description!),
                "Птица" => new Bird(animalType, animalSubtype!, description!),
                "Земноводное" => new Amphibian(animalType, animalSubtype!, description!),
                _ =>  new NullAnimal(),
            };
        
    }
}
