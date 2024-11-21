using System;
using System.Text.RegularExpressions;

namespace SchoolManager.Services
{
    public class ValidationService
    {
        public bool ValidateEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public bool ValidatePhone(string phone)
        {
            string pattern = @"^\d{8}$";
            return Regex.IsMatch(phone, pattern);
        }

        public bool ValidateStudentId(string studentId)
        {
            string pattern = @"^\d{6}$";
            return Regex.IsMatch(studentId, pattern);
        }
    }
}