using APIconcesionario.Models;
using APIconcesionario.Interface;

namespace APIconcesionario.Repository
{
    public class CarroRepository : ICarroRepository
    {
        private readonly IMarcaRepository _marcaRepository;

        private static List<Carro> carros = new List<Carro>
        {
            new Carro {Id = 1, MarcaId = 1, Marca = "Toyota", Color = "Negro", Placa = "ABC123", Precio = 20000},

            new Carro {Id = 2, MarcaId = 2, Marca = "Renault", Color = "Blanco", Placa = "DEF456", Precio = 30000},

            new Carro {Id = 3, MarcaId = 3, Marca = "Chevrolet", Color = "Rojo", Placa = "GHI789", Precio = 50000}
        };


        public CarroRepository(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }


        public IEnumerable<Carro> GetCarros()
        {
            return carros;
        }

        public Carro? getCarroPorId(int id)
        {
            return carros.FirstOrDefault(c => c.Id == id);
        }

        public bool existeCarroConMarca(int marcaId)
        {
            return carros.Any(c => c.MarcaId == marcaId);
        }

        public string createCarro(Carro carro)
        {
            if (carros.Any(c => c.Id == carro.Id))
            {
                return "Ya existe un carro con ese Id";
            }

            if (string.IsNullOrWhiteSpace(carro.Color))
            {
                return "El color no puede estar vacío";
            }

            if (string.IsNullOrWhiteSpace(carro.Placa))
            {
                return "La placa no puede estar vacía";
            }

            if (carro.Precio <= 0)
            {
                return "El precio debe ser mayor que cero";
            }


            var marca = _marcaRepository.getMarcaPorId(carro.MarcaId);


            if (marca == null)
            {
                return "No se puede registrar el carro porque la marca no existe";
            }


            carro.Marca = marca.Nombre;


            decimal descuento = 0;


            if (marca.Nombre == "Toyota")
            {
                descuento = 0.15m;
            }
            else if (marca.Nombre == "Renault")
            {
                descuento = 0.25m;
            }
            else if (marca.Nombre == "Chevrolet")
            {
                descuento = 0.20m;
            }


            carro.Precio = carro.Precio - (carro.Precio * descuento);


            carros.Add(carro);


            return "Carro creado exitosamente";
        }

        public string updateCarro(int Id, Carro carro)
        {
            var carroExistente = carros.FirstOrDefault(c => c.Id == Id);


            if (carroExistente == null)
            {
                return "Carro no encontrado";
            }


            var marca = _marcaRepository.getMarcaPorId(carro.MarcaId);


            if (marca == null)
            {
                return "La marca no existe";
            }


            if (string.IsNullOrWhiteSpace(carro.Color))
            {
                return "El color no puede estar vacío";
            }


            if (string.IsNullOrWhiteSpace(carro.Placa))
            {
                return "La placa no puede estar vacía";
            }


            if (carro.Precio <= 0)
            {
                return "El precio debe ser mayor que cero";
            }


            carroExistente.MarcaId = carro.MarcaId;

            carroExistente.Marca = marca.Nombre;

            carroExistente.Color = carro.Color;

            carroExistente.Placa = carro.Placa;

            carroExistente.Precio = carro.Precio;


            return "Carro actualizado exitosamente";
        }


        public string deleteCarro(int Id)
        {
            var carroExistente =
                carros.FirstOrDefault(c => c.Id == Id);


            if (carroExistente != null)
            {
                carros.Remove(carroExistente);

                return "Carro eliminado exitosamente";
            }


            return "Carro no encontrado";
        }
    }
}