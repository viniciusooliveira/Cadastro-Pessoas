using System;

namespace API.Models.Bases
{
    /// <summary>
    /// Classe base de Pessoa
    /// </summary>
    public class PersonBase
    {
        /// <summary>
        /// Nome Completo
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// CPF
        /// </summary>
        public string Document { get; set; }
        /// <summary>
        /// Data de Nascimento
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Número de Telefone
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}