using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldenGateAPI.Entities
{
    public class Lugaro_Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoBarra { get; set; }
        public int IdProductoClase { get; set; }
        public int IdProveedor { get; set; }
        public decimal StockMinimo { get; set; }
        public decimal IVA { get; set; }
      
        public decimal PrecioMinorista { get; set; }
        public decimal PrecioMayorista { get; set; }
        public decimal MayoristaApartirDe { get; set; }

        public int IdProductoOrigen { get; set; }
        public int Activo { get; set; }
        public int IdMoneda { get; set; }
        public int IdFamilia { get; set; }
        public int IdUnidad { get; set; }
        public decimal StockEnPrincipal { get; set; }
        public decimal PorcentajeDescuento { get; set; }
        public int IdTipo { get; set; }
        public string CodigoUnico { get; set; }






    }
}
