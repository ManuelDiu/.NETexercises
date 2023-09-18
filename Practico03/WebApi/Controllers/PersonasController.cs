using BusinessLayer.IBLs;
using Microsoft.AspNetCore.Mvc;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {

        private readonly IBL_Personas _bl;

        public PersonasController(IBL_Personas bl)
        {
            _bl = bl;
        }


        // GET: api/<PersonasController>
        [ProducesResponseType(typeof(List<Persona>), 200)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bl.Get());
        }

        [ProducesResponseType(typeof(Persona), 200)]
        [HttpGet("{documento}")]
        public IActionResult Get(string documento)
        {
            return Ok(_bl.Get(documento));
        }

        // POST api/<PersonasController>
        [HttpPost]
        public void Post([FromBody] Persona persona)
        {
            _bl.Insert(persona);
        }

        // PUT api/<PersonasController>/5
        [HttpPut]
        public void Put([FromBody] Persona persona)
        {
            _bl.Update(persona);
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{documento}")]
        public void Delete(string documento)
        {
            _bl.Delete(documento);
        }
    }
}
