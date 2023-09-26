using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeonBankPrueba.Shared
{
    public class CuentaBancaria
    {
        public int CubId { get; set; }
        public int TpcId { get; set; }
        public int BcoId { get; set; }
        public int CliId { get; set; }
        public string CubCodigo { get; set; }
        public string CubDescripcion { get; set; }
        public bool CubEstadoActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
