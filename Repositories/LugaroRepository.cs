using Dapper;
using GoldenGateAPI.Data;
using GoldenGateAPI.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GoldenGateAPI.Repositories
{
    public class LugaroRepository : ILugaroRepository
    {
        private SqlConfiguration _connectionString;

        public LugaroRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            //return new SqlConnection(_connectionString.ConnectionString);
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<Lugaro_Producto>> GetAllProductos()
        {

            try
            { 
            var db = dbConnection();
            var sql = @"SELECT p.id_producto  as IdProducto
                      ,p.producto as NombreProducto
                      ,p.codigo as CodigoBarra
                      ,null as IdProductoClase
                      ,p.id_proveedor as IdProveedor
                      ,0 as StockMinimo
                      ,0 as IVA
                      ,p.costo  Costo
                      ,p.precio PrecioMinorista
                      ,p.precio  PrecioMayorista
                      ,0 as MayoristaApartirDe
                      ,null PM2
                      ,null PM2_ApartirDe
                      ,null PM3
                      ,null PM3_ApartirDe
                      ,null IdProductoOrigen
                      ,null CantidadOrigen
                      ,null as Activo
                      ,null as EsCompuesto
                      ,p.descripcion as OBS
                      ,p.costo as CostoUltimo
                      ,null CostoUltimoFecha
                      ,null AlarmarStock
                      ,p.codigo CodigoUnico
                      ,null Garantia
                      ,null Ubicacion
                      ,null IdMoneda
                      ,null SeVende
                      ,null IdFamilia
                      ,null IdGrupo
                      ,null IdUnidad
                      ,null NombreGenerico
                      ,null ORIGEN      
                      ,null IdProductoReal
                      ,null IdClasiDivision
                      ,null IdClasiSeccion
                      ,null IdClasiFamilia
                      ,null ALTA
                      ,null OrigenALIAS
                      ,null COSTO_USD
                      ,null COSTO_RS
                      ,null COSTO_PS
                      ,null COSTO_Eu
                      ,null PRECIO_USD
                      ,null PRECIO_RS
                      ,null PRECIO_PS
                      ,null PRECIO_Eu
                      ,null SELLO
                      ,null PRECIO_MAY_USD
                      ,null PRECIO_MAY_RS
                      ,null PRECIO_MAY_PS
                      ,null PRECIO_MAY_Eu
                      ,p.precio as PVendedor_GS
                      ,null PVendedor_USD
                      ,null PorcentajeComision
                      ,null IdUltimaCompra
                      ,null IdUltimaVenta      
                      ,sum(s.cantidad) as StockEnPrincipal
                      ,null PorcentajeDescuento
                      ,null IdTipo
                      ,null Jerarquia
                      ,null IdProductoPadre 
                      ,p.codigo as CodigoUnico
                  FROM public.productos p 
                  inner join public.stock s on p.id_producto = s.id_producto 
                  group by p.id_producto";

                return await db.QueryAsync<Lugaro_Producto>(sql, new { });

            }
            catch(Exception ex)
            {
                return null;
            }

            
        }
    }
}
