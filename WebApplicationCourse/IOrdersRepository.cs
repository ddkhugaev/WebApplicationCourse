using WebApplicationCourse.Models;

namespace WebApplicationCourse
{
    public interface IOrdersRepository
    {
        public Order TryGetById(Guid id);
        public List<Order> GetAll();
        public void Add(Order order);
    }
}
