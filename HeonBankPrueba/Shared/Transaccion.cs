using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeonBankPrueba.Shared
{
    public class Transaccion
    {
        public int TrnsId { get; set; }
        public int CliId { get; set; }
        public int CubId { get; set; }
        public int TpoTrnsId { get; set; }
        public int FrmPgoId { get; set; }
        public decimal TrnsMonto { get; set; }
        public bool TrnsEstadoActivo { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
