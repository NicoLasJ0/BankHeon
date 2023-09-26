namespace HeonBankPrueba.Client.Models
{
    public class TransaccionDtoOut
    {
        public int Id { get; set; }
        public string CodigoIdentificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public decimal Monto { get; set; }
        public string CuentaBancariaCodigo { get; set; }
        public string TipoTransaccion { get; set; }
        public string FormaPago { get; set; }
        public string TipoIdentificacion { get; set; }
        public DateTime FechaConsignacion { get; set; }
    }
}
