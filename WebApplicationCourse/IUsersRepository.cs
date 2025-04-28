using WebApplicationCourse.Models;

namespace WebApplicationCourse
{
    public interface IUsersRepository
    {
        public List<User> GetAll();
        public User TryGetById(Guid id);
        public void Add(User user);
    }
}
