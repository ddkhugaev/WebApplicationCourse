using System.ComponentModel.DataAnnotations;

namespace WebApplicationCourse.Models
{
    public class Role
    {
        [Required]
        public string Name { get; set; }
    }
}
