using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; } // Ссылка на документ
        public string LevelEdu { get; set; } // Уровень подготовки
        public string Years { get; set; }
        public string Teacher { get; set; } // Преподаватель
        public int? CourseId { get; set; }
        public Course Course { get; set; }
        public int? DirectionId { get; set; }
        public Direction Direction { get; set; }
    }
}
