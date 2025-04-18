using System.ComponentModel.DataAnnotations;

namespace WebApplicationCourse.Models
{
    public class Product
    {
        static int instanceCounter = 0;
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано название")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Длина логина должна быть от 2 до 25 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана цена")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Не указано описание")]
        public string Description { get; set; }
        public string ImagePath { get; set; } = "/images/productImage.jpg";

        public Product()
        {
            Id = instanceCounter;
            instanceCounter++;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nCost: {Cost}р.";
        }
    }
}
