using System.Text.Json.Serialization;
using API.Models.Bases;
using CrossCutting.Mappers.Contracts;
using Domain.Models;

namespace API.Models.Requests
{
    /// <summary>
    /// Classe de Requisição de Pessoa
    /// </summary>
    public class PersonRequest : PersonBase, IToObjectMapper<Person>
    {
        #region Properties

        [JsonIgnore]
        public long Id { get; set; }

        #endregion

        #region Implements

        public Person MapTo()
                {
                    return new Person
                    {
                        Id = Id,
                        Document = Document,
                        Email = Email,
                        Name = Name,
                        BirthDate = BirthDate,
                        PhoneNumber = PhoneNumber
                    };
                }

        #endregion
        
    }
}