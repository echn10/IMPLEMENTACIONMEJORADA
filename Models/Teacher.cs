using System;

namespace SchoolManager.Models
{
    public class Teacher : Person
    {
        public string TeacherId { get; set; }
        public string Department { get; set; }
        public List<Course> CoursesTeaching { get; set; } = new List<Course>();

        public override string GetFullInfo()
        {
            return $"Teacher: {Name} (ID: {TeacherId}, Dept: {Department})";
        }
    }
}