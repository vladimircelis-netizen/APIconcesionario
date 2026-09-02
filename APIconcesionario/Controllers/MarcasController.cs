using APIconcesionario.Models;
using APIconcesionario.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIconcesionario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarcasController : ControllerBase
    {
        private readonly ICarroRepository _carroRepository;
        private readonly IMarcaRepository _marcaRepository;

        public MarcasController(IMarcaRepository marcaRepository, ICarroRepository carroRepository)
        {
            _marcaRepository = marcaRepository;
            _carroRepository = carroRepository;
        }

        [HttpGet("GetMarcas")]
        public IEnumerable<Marca> GetMarcas()
        {
            return _marcaRepository.GetMarcas();
        }

        [HttpPost("CreateMarca")]
        public string Post([FromBody] Marca marca)
        {
            var respuesta = _marcaRepository.createMarca(marca);
            return respuesta;
        }
        [HttpPut("UpdateMarca/{id}")]
        public string Put(int id, [FromBody] Marca marca)
        {
            var respuesta = _marcaRepository.updateMarca(id, marca);
            return respuesta;
        }
        [HttpDelete("DeleteMarca/{id}")]
        public string DeleteMarca(int id)
        {
            if (_carroRepository.existeCarroConMarca(id))
            {
                return "No se puede eliminar la marca porque tiene carros asociados";
            }

            var respuesta = _marcaRepository.deleteMarca(id);
            return respuesta;
        }

    }
}
