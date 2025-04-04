using WebApplicationCourse.Models;

namespace WebApplicationCourse
{
    public interface ICartsRepository
    {
        public List<Cart> GetAll();
        public Cart TryGetById(string userId);
        public void Add(Product product, string userId);
        public void Remove(Cart cart);
    }
}
