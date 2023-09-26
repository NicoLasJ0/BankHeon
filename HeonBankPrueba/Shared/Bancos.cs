using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeonBankPrueba.Shared
{
    public class Bancos
    {
        public int BcoId { get; set; }
        public string BcoNombre { get; set; }
        public bool BcoEstadoActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
