using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Department> Departments { get; set; }
        public Faculty()
        {
            Departments = new List<Department>();
        }
    }
}
