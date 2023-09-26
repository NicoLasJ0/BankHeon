using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeonBankPrueba.Shared
{
    public class TipoCuenta
    {
        public int TpcId { get; set; }
        public string TpcDescripcion { get; set; }
        public bool TpcEstadoActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
