namespace DataModels.Models
{
    internal class NullAnimal : IAnimal
    {
        public int Id { get; set; } = -1;
        public string AnimalType { get; set; } = "Undefined";
        public string? AnimalSubType { get; set; } = "Undefined";
        public string? Description { get; set; } = "Undefined";

        public NullAnimal() { }
    }
}
