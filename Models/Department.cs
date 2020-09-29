using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? FacultyId { get; set; } // ссылка на связанную модель Faculty
        public Faculty Faculty { get; set; }
        public ICollection<Direction> Directions { get; set; }
        public Department()
        {
            Directions = new List<Direction>();
        }
    }
}
