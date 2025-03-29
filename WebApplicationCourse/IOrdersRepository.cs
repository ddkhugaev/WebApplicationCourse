using WebApplicationCourse.Models;

namespace WebApplicationCourse
{
    public interface IOrdersRepository
    {
        public Cart TryGetById(string userId);
        public List<Cart> GetAll();
        public void Add(Cart cart);
    }
}
