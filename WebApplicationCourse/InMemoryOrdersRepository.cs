using WebApplicationCourse.Models;

namespace WebApplicationCourse
{
    public class InMemoryOrdersRepository : IOrdersRepository
    {
        List<Cart> orders = new List<Cart>();
        public Cart TryGetById(string userId)
        {
            return orders.FirstOrDefault(cart => cart.UserId == userId);
        }
        public List<Cart> GetAll()
        {
            return orders;
        }
        public void Add(Cart cart)
        {
            orders.Add(cart);
        }
    }
}
