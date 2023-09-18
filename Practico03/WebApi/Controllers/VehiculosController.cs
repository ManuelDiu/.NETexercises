using BusinessLayer.IBLs;
using Microsoft.AspNetCore.Mvc;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {

        private readonly IBL_Vehiculos _bl;

        public VehiculosController(IBL_Vehiculos bl)
        {
            _bl = bl;
        }

        // GET: api/<VehiculosController>
        [ProducesResponseType(typeof(List<Vehiculo>), 200)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bl.Get());
        }

        // GET api/<VehiculosController>/5
        [ProducesResponseType(typeof(Vehiculo), 200)]
        [HttpGet("{matricula}")]
        public IActionResult Get(string matricula)
        {
            return Ok(_bl.Get(matricula));
        }

        // POST api/<VehiculosController>
        [HttpPost]
        public void Post([FromBody] Vehiculo vehiculo)
        {
            _bl.Insert(vehiculo);
        }

        // PUT api/<VehiculosController>/5
        [HttpPut]
        public void Put([FromBody] Vehiculo vehiculo)
        {
            _bl.Update(vehiculo);
        }

        // DELETE api/<VehiculosController>/5
        [HttpDelete("{matricula}")]
        public void Delete(string matricula)
        {
            _bl.Delete(matricula);
        }
    }
}
