namespace APIconcesionario.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public int MarcaId { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public string Placa { get; set; }
        public decimal Precio { get; set; }
    }
}
