namespace DataModels
{
    public interface IAnimal
    {
        public  int Id { get; set; }
        public string AnimalType { get; set; }
        public  string? AnimalSubType { get; set; }
        public  string? Description { get; set; }
    }
}
