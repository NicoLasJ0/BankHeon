using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeonBankPrueba.Shared
{
    public class TipoTransaccion
    {
        public int TpoTrnsId { get; set; }
        public string TpoTrnsDescripcion { get; set; }
        public bool TpoTrnsEstadoActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
