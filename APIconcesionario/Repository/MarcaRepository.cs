using APIconcesionario.Models;
using APIconcesionario.Interface;
namespace APIconcesionario.Repository
{
    public class MarcaRepository : IMarcaRepository 
    {
        private static List<Marca> marcas = new List<Marca>
        {
            new Marca { Id = 1, Nombre = "Toyota", Descripcion = "Marca japonesa de automóviles" },
            new Marca { Id = 2, Nombre = "Ford", Descripcion = "Marca estadounidense de automóviles" },
            new Marca { Id = 3, Nombre = "BMW", Descripcion = "Marca alemana de automóviles" }
        };

        public IEnumerable<Marca> GetMarcas()
        {
            return marcas;
        }

        public Marca? getMarcaPorId(int id)
        {
            return marcas.FirstOrDefault(m => m.Id == id);
        }

        public string createMarca(Marca marca)
        {
            marcas.Add(marca);
            return "Marca creada exitosamente";
        }

        public string updateMarca(int Id, Marca marca)
        {
            var marcaExistente = marcas.FirstOrDefault(m => m.Id == Id);
            if (marcaExistente != null)
            {
                marcaExistente.Nombre = marca.Nombre;
                marcaExistente.Descripcion = marca.Descripcion;
                return "Marca actualizada exitosamente";
            }
            return "Marca no encontrada";
        }

        public string deleteMarca(int Id)
        {
            var marcaExistente = marcas.FirstOrDefault(m => m.Id == Id);
            if (marcaExistente != null)
            {
                marcas.Remove(marcaExistente);
                return "Marca eliminada exitosamente";
            }
            return "Marca no encontrada";
        }
    }
}
