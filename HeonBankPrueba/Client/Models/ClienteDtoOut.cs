namespace HeonBankPrueba.Client.Models
{
    public class ClienteDtoOut
    {
        public int CliId { get; set; }
        public string TipoCuenta { get; set; }
        public string BancoNombre { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool EstadoActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
