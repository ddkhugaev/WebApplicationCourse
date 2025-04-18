using WebApplicationCourse.Models;

namespace WebApplicationCourse
{
    public class InMemoryProductsRepository : IProductsRepository
    {
        List<Product> products =
            [
            new Product(){ Name = "Картье", Cost = 200, Description = "Хороший"},
            new Product(){ Name = "Портье", Cost = 4500, Description = "Тоже хороший"},
            new Product(){ Name = "Еще товар", Cost = 300, Description = "Неплохой"}
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
        public void EditById(int id, Product editProduct)
        {
            var product = TryGetById(id);
            product.Name = editProduct.Name;
            product.Cost = editProduct.Cost;
            product.Description = editProduct.Description;
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}
