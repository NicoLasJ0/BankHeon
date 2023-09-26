using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeonBankPrueba.Shared
{
    public class FormaPago
    {
        public int FrmPgoId { get; set; }
        public string FrmPgoDescripcion { get; set; }
        public bool FrmPgoEstadoActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
