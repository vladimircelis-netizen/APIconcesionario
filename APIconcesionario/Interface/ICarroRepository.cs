using APIconcesionario.Models;
namespace APIconcesionario.Interface
{
    public interface ICarroRepository
    {
        IEnumerable<Carro> GetCarros();
        Carro? getCarroPorId(int id);
        string createCarro(Carro carro);
        string updateCarro(int Id, Carro carro);
        string deleteCarro(int Id);
        bool existeCarroConMarca(int marcaId);
    }
}
