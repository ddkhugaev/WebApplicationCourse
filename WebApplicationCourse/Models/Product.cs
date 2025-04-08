namespace WebApplicationCourse.Models
{
    public class Product
    {
        static int instanceCounter = 0;
        public int Id { get; }
        public string Name { get; }
        public decimal Cost { get; }
        public string Description { get; }
        public string ImagePath { get; }
        public Product(string name, decimal cost, string description, string imagePath)
        {
            Id = instanceCounter;
            Name = name;
            Cost = cost;
            Description = description;
            ImagePath = imagePath;
            instanceCounter++;
        }
        public Product(string name, decimal cost, string description)
        {
            Id = instanceCounter;
            Name = name;
            Cost = cost;
            Description = description;
            ImagePath = "/images/productImage.jpg";
            instanceCounter++;
        }
        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nCost: {Cost}р.";
        }
    }
}
