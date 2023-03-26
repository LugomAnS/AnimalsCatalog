namespace DataModels.Models
{
    internal class NullAnimal : IAnimal
    {
        public string AnimalType { get; set; } = "Undefined";
        public string? AnimalSubType { get; set; } = "Undefined";
        public string? Description { get; set; } = "Undefined";

        public NullAnimal() { }
    }
}
