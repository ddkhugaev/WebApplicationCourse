using WebApplicationCourse.Models;

namespace WebApplicationCourse
{
    public class InMemoryUsersRepository : IUsersRepository
    {
        List<User> users = new List<User>() { new User() { Login="ddkhugaev", Password="1234", Id=Guid.NewGuid()} };
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

        public bool IsLoginExist(string login)
        {
            User user = users.FirstOrDefault(x => x.Login == login);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public bool IsPasswordCorrect(string login, string password)
        {
            User user = users.FirstOrDefault(x => x.Login == login);
            if (user != null)
            {
                if (user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public void Remove(Guid id)
        {
            if (TryGetById(id) != null)
            {
                users.Remove(TryGetById(id));
            }
        }
    }
}
