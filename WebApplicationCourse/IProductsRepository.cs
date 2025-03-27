using WebApplicationCourse.Models;

namespace WebApplicationCourse
{
    public interface IProductsRepository
    {
        public List<Product> GetAll();
        public Product TryGetById(int id);
    }
}
