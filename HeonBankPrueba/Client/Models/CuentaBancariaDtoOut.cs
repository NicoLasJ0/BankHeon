namespace HeonBankPrueba.Client.Models
{
    public class CuentaBancariaDtoOut
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set;}
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool EstadoActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
