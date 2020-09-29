using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<Content> Contents { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Faculty> Faculties { get; set; }
        public IEnumerable<Direction> Directions { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
