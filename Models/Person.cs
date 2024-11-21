using System;

namespace SchoolManager.Models
{
    public abstract class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }

        public abstract string GetFullInfo();
    }
}