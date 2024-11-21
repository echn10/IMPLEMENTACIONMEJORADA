using System;

namespace SchoolManager.Models
{
    public class Student : Person
    {
        public string StudentId { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();

        public override string GetFullInfo()
        {
            return $"Student: {Name} (ID: {StudentId})";
        }
    }
}