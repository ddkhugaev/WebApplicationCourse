using WebApplicationCourse.Models;

namespace WebApplicationCourse
{
    public class InMemoryOrdersRepository : IOrdersRepository
    {
        List<Order> orders = new List<Order>();
        public Order TryGetById(Guid id)
        {
            return orders.FirstOrDefault(order => order.Id == id);
        }
        public List<Order> GetAll()
        {
            return orders;
        }
        public void Add(Order order)
        {
            orders.Add(order);
        }
    }
}
