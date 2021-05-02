using System;
using CrossCutting.Mappers.Contracts;
using Domain.Models;
using Domain.Models.Bases;

namespace Mariadb.Entities
{
    public class PersonEntity : Identifiable, IObjectMapper<Person, PersonEntity>
    {
        #region Properties
        
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        #endregion

        #region Constructors

        public PersonEntity() { }

        public PersonEntity(Person input) => MapFrom(input);

        #endregion

        #region Implements

        public PersonEntity MapFrom(Person input)
        {
            if (input != null)
            {
                Id = input.Id;
                Name = input.Name;
                Document = input.Document;
                BirthDate = input.BirthDate;
                Email = input.Email;
                PhoneNumber = input.PhoneNumber;
            }

            return this;
        }

        public Person MapTo()
        {
            return new Person()
            {
                Id = Id,
                Name = Name,
                Document = Document,
                BirthDate = BirthDate,
                Email = Email,
                PhoneNumber = PhoneNumber
            };
        }

        #endregion
    }
}