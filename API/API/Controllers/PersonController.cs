using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Models.Requests;
using API.Models.Results;
using Domain.Business.Contracts;
using Domain.Models.Bases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Pessoas
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class PersonController : BaseController
    {
        #region Properties
        
        private readonly IPersonBusiness _personBusiness;
        
        #endregion
        
        
        #region Constructors

        /// <summary>
        /// Construtor da controller
        /// </summary>
        /// <param name="personBusiness">Injeção de implementação da business</param>
        public PersonController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }
        
        #endregion
        
        
        #region Methods
        
        /// <summary>
        /// Lista todas as Pessoas
        /// </summary>
        /// <returns>Lista de Pessoas</returns>
        [HttpGet()]
        [ProducesResponseType(typeof(IList<PersonResult>), (int) HttpStatusCode.OK)]
        public async Task<IList<PersonResult>> List()
        {
            var result = await _personBusiness.ListAll();
            return result?.Select(x => new PersonResult(x)).ToList();
        }

        /// <summary>
        /// Busca uma Pessoa
        /// </summary>
        /// <param name="id">Identificador da Pessoa</param>
        /// <returns>Uma Pessoa selecionada</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonResult), (int) HttpStatusCode.OK)]
        public async Task<PersonResult> Get(long id)
        {
            var result = await _personBusiness.Get(new Identifiable(id));
            if (result != null)
                return new PersonResult(result);

            return null;
        }
        
        /// <summary>
        /// Adiciona uma Pessoa
        /// </summary>
        /// <param name="request">Objeto de requisição de uma Pessoa</param>
        /// <returns>Pessoa cadastrada</returns>
        [HttpPost]
        [ProducesResponseType(typeof(PersonResult), (int) HttpStatusCode.OK)]
        public async Task<PersonResult> Post([FromBody] PersonRequest request)
        {
            var result = await _personBusiness.Save(request.MapTo());
            return new PersonResult(result);
        }

        /// <summary>
        /// Atualiza uma Pessoa
        /// </summary>
        /// <param name="id">Identificador da Pessoa</param>
        /// <param name="request">Objeto de requisição de uma Pessoa</param>
        /// <returns>Pessoa atualizada</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PersonResult), (int) HttpStatusCode.OK)]
        public async Task<PersonResult> Put(long id, [FromBody] PersonRequest request)
        {
            request.Id = id;
            var result = await _personBusiness.Save(request.MapTo());
            return new PersonResult(result);
        }

        /// <summary>
        /// Remove uma Pessoa
        /// </summary>
        /// <param name="id">Identificador da Pessoa</param>
        /// <returns>Pessoa removida</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PersonResult), (int) HttpStatusCode.OK)]
        public async Task<PersonResult> Delete(long id)
        {
            var result = await _personBusiness.Delete(new Identifiable(id));
            
            return new PersonResult(result);
        }
        
        #endregion
    }
}