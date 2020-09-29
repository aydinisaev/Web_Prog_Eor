using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Direction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DepartmentId { get; set; } // ссылка на связанную модель Department
        public Department Department { get; set; }
        public ICollection<Course> Courses { get; set; }
        public Direction()
        {
            Courses = new List<Course>();
        }
    }
}
