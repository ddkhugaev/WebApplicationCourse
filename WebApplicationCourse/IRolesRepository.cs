using WebApplicationCourse.Models;

namespace WebApplicationCourse
{
    public interface IRolesRepository
    {
        public List<Role> GetAll();
        public Role TryGetByName(string name);
        public void Add(Role role);
        public void Remove(string name);
    }
}
