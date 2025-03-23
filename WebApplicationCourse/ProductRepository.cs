using WebApplicationCourse.Models;

namespace WebApplicationCourse
{
    public class ProductRepository
    {
        static List<Product> products = [new Product("Картье", 200, "Хороший"), new Product("Портье", 4500, "Тоже хороший")];
        public List<Product> GetAll()
        {
            return products;
        }
        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }
    }
}
