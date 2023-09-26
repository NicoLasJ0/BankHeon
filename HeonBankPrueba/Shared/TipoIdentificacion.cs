using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeonBankPrueba.Shared
{
    public class TipoIdentificacion
    {
        public int TpiId { get; set; }
        public string TpiDescripcion { get; set; }
        public string TpiAbreviacion { get; set; }
        public bool TpiEstadoActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
