using System;
using System.Linq;
using SchoolManager.Models;

namespace SchoolManager.Services
{
    public class StudentService : DataService<Student>
    {
        public decimal CalculateAverageGrade(string studentId)
        {
            var student = Find(s => s.StudentId == studentId).FirstOrDefault();
            if (student == null) return 0;

            return student.Courses
                .SelectMany(c => c.Grades)
                .Average(g => g.Score);
        }

        public List<Course> GetStudentCourses(string studentId)
        {
            return Find(s => s.StudentId == studentId)
                .FirstOrDefault()
                ?.Courses ?? new List<Course>();
        }
    }
}