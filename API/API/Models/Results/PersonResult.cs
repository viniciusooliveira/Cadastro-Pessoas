using API.Models.Bases;
using CrossCutting.Mappers.Contracts;
using Domain.Models;

namespace API.Models.Results
{
    /// <summary>
    /// Classe de Resultado de Pessoa
    /// </summary>
    public class PersonResult : PersonBase, IFromObjectMapper<Person, PersonResult>
    {
        #region Properties

        /// <summary>
        /// Identificador de Pessoa
        /// </summary>
        public long Id { get; set; }
        
        #endregion

        #region Constructors

        public PersonResult()
        {
        }

        public PersonResult(Person input) => MapFrom(input);

        #endregion

        #region Implements

        public PersonResult MapFrom(Person input)
        {
            Id = input.Id;
            Name = input.Name;
            Document = input.Document;
            BirthDate = input.BirthDate;
            Email = input.Email;
            PhoneNumber = input.PhoneNumber;
            
            return this;
        }

        #endregion
    }
}