using WebApplicationCourse.Models;

namespace WebApplicationCourse
{
    public class InMemoryProductsRepository : IProductsRepository
    {
        List<Product> products =
            [
            new Product("Картье", 200, "Хороший", "/images/productImage.jpg"),
            new Product("Портье", 4500, "Тоже хороший", "/images/productImage.jpg"),
            new Product("Еще товар", 300, "Неплохой", "/images/productImage.jpg")
            ];
        public List<Product> GetAll()
        {
            return products;
        }
        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }
        public void TryRemoveById(int id)
        {
            if (TryGetById(id) != null)
            {
                products.Remove(TryGetById(id));
            }
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}
