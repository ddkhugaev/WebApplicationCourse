using WebApplicationCourse.Models;

namespace WebApplicationCourse
{
    public class InMemoryRolesRepository : IRolesRepository
    {
        private readonly List<Role> roles = new List<Role>();
        public List<Role> GetAll()
        {
            return roles;
        }
        public Role TryGetByName(string name)
        {
            return roles.FirstOrDefault(x => x.Name == name);
        }
        public void Add(Role role)
        {
            roles.Add(role);
        }
        public void Remove(string name)
        {
            roles.Remove(TryGetByName(name));
        }
    }
}
