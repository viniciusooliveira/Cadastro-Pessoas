using System;
using Domain.Models.Bases;

namespace Domain.Models
{
    public class Person : Identifiable
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}