using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DirectionId { get; set; } // ссылка на связанную модель Direction
        public Direction Direction { get; set; }
        public ICollection<Content> Content { get; set; }
        public Course()
        {
            Content = new List<Content>();
        }
    }
}
