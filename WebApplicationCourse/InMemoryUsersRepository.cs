using WebApplicationCourse.Models;

namespace WebApplicationCourse
{
    public class InMemoryUsersRepository : IUsersRepository
    {
        List<User> users = new List<User>();
        public List<User> GetAll()
        {
            return users;
        }

        public User TryGetById(Guid id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        public void Add(User user)
        {
            users.Add(user);
        }
    }
}
