using Microsoft.AspNetCore.Mvc;
using APIconcesionario.Models;
using APIconcesionario.Interface;
namespace APIconcesionario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarrosController : ControllerBase  
    {
        private readonly ICarroRepository _carroRepository;
        public CarrosController(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;

        }
        [HttpGet("GetCarros")]
        public IEnumerable<Carro> GetCarros()
        {
            return _carroRepository.GetCarros();
        }
        [HttpPost("CreateCarro")]
        public string Post([FromBody] Carro carro)
        {
            var respuesta = _carroRepository.createCarro(carro);
            return respuesta;
        }
        [HttpPut("UpdateCarro/{id}")]
        public string Put(int id, [FromBody] Carro carro)
        {
            var respuesta = _carroRepository.updateCarro(id, carro);
            return respuesta;
        }
        [HttpDelete("DeleteCarro/{id}")]
        public string Delete(int id)
        {
            var respuesta = _carroRepository.deleteCarro(id);
            return respuesta;
        }
    }
}
