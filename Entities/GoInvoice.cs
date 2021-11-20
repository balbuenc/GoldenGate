using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldenGateAPI.Entities
{
    public class GoInvoice
    {
        
        public int id_factura{ get; set; } 
        public int id_proveedor{ get; set; } 
        public int id_cliente{ get; set; } 
        public string nro_factura{ get; set; } 
        public DateTime fecha_emision{ get; set; } 
        
        public DateTime fecha_cobro{ get; set; } 
        
        public decimal monto{ get; set; } 
        
        public int id_moneda{ get; set; } 
        
        public string concepto{ get; set; } 
        
        public string monto_neto{ get; set; }
        public string nombres { get; set; } 
        public string apellidos{ get; set; } 
        
        public string ruc { get; set; } 
        
        public string moneda { get; set; }
    }
}
