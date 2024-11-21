using System;
using System.Collections.Generic;

namespace SchoolManager.Models
{
    public class Course
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public List<Grade> Grades { get; set; } = new List<Grade>();
    }
}