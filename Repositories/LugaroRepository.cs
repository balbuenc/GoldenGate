using Dapper;
using GoldenGateAPI.Data;
using GoldenGateAPI.Entities;
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

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<Lugaro_Producto>> GetAllProductos()
        {
            var db = dbConnection();
            var sql = @"SELECT  [IdProducto]
                      ,[NombreProducto]
                      ,[CodigoBarra]
                      ,[IdProductoClase]
                      ,[IdProveedor]
                      ,[StockMinimo]
                      ,[IVA]
                      ,[Costo]
                      ,[PrecioMinorista]
                      ,[PrecioMayorista]
                      ,[MayoristaApartirDe]
                      ,[PM2]
                      ,[PM2_ApartirDe]
                      ,[PM3]
                      ,[PM3_ApartirDe]
                      ,[IdProductoOrigen]
                      ,[CantidadOrigen]
                      ,[Activo]
                      ,[EsCompuesto]
                      ,[OBS]
                      ,[CostoUltimo]
                      ,[CostoUltimoFecha]
                      ,[AlarmarStock]
                      ,[CodigoUnico]
                      ,[Garantia]
                      ,[Ubicacion]
                      ,[IdMoneda]
                      ,[SeVende]
                      ,[IdFamilia]
                      ,[IdGrupo]
                      ,[IdUnidad]
                      ,[NombreGenerico]
                      ,[ORIGEN]      
                      ,[IdProductoReal]
                      ,[IdClasiDivision]
                      ,[IdClasiSeccion]
                      ,[IdClasiFamilia]
                      ,[ALTA]
                      ,[OrigenALIAS]
                      ,[COSTO_USD]
                      ,[COSTO_RS]
                      ,[COSTO_PS]
                      ,[COSTO_Eu]
                      ,[PRECIO_USD]
                      ,[PRECIO_RS]
                      ,[PRECIO_PS]
                      ,[PRECIO_Eu]
                      ,[SELLO]
                      ,[PRECIO_MAY_USD]
                      ,[PRECIO_MAY_RS]
                      ,[PRECIO_MAY_PS]
                      ,[PRECIO_MAY_Eu]
                      ,[PVendedor_GS]
                      ,[PVendedor_USD]
                      ,[PorcentajeComision]
                      ,[IdUltimaCompra]
                      ,[IdUltimaVenta]      
                      ,[StockEnPrincipal]
                      ,[PorcentajeDescuento]
                      ,[IdTipo]
                      ,[Jerarquia]
                      ,[IdProductoPadre] 
                      ,[CodigoUnico]
                  FROM [LUGARO].[dbo].[Productos]";


            return await db.QueryAsync<Lugaro_Producto>(sql, new { });
        }
    }
}
