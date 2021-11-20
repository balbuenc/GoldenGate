using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldenGateAPI.Entities
{
    public class GoRequest
	{

        public int id_solicitud { get; set; }

        public int id_funcionario { get; set; }

        public DateTime fecha  { get; set; }

        public int id_estado { get; set; }

        public string razon_social { get; set; }
        public string ruc { get; set; }

        public string telefono1 { get; set; }

        public string telefono2 { get; set; }

        public string email { get; set; }
        public string direccion { get; set; }

        public string representante { get; set; }

        public string cargo { get; set; }
        public string tipo { get; set; }
    }

}
