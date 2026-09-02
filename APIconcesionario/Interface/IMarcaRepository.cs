using APIconcesionario.Models;

namespace APIconcesionario.Interface
{
    public interface IMarcaRepository
    {
        IEnumerable<Marca> GetMarcas();
        Marca? getMarcaPorId(int id);
        string createMarca(Marca marca);
        string updateMarca(int Id, Marca marca);
        string deleteMarca(int Id);

    }
}
