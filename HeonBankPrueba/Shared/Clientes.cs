using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeonBankPrueba.Shared
{
    public class Clientes
    {
        public int CliId { get; set; }
        public int TpiId { get; set; }
        public string CliCodigo { get; set; }
        public string CliNombres { get; set; }
        public string CliApellidos { get; set; }
        public bool CliEstadoActivo { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
