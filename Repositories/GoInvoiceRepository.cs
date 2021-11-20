using Dapper;
using GoldenGateAPI.Data;
using GoldenGateAPI.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldenGateAPI.Repositories
{
    public class GoInvoiceRepository : IGoInvoiceRepository
    {
        private SqlConfiguration _connectionString;

        public GoInvoiceRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<GoInvoice>> GetAllInvoices()
        {

            try
            {
                var db = dbConnection();
                var sql = @"SELECT f.id_factura, f.id_proveedor, f.id_cliente, f.nro_factura, f.fecha_emision, f.fecha_cobro, f.monto, f.id_moneda, f.concepto, f.monto_neto,
                            p.nombres , p.apellidos, p.ruc , m.moneda 
                            FROM public.facturas f 
                            left outer join proveedores p on p.id_proveedor = f.id_proveedor
                            left outer join monedas m on m.id_moneda = f.id_moneda ;";

                return await db.QueryAsync<GoInvoice>(sql, new { });

            }
            catch (Exception ex)
            {
                return null;
            }



        }
    }
}
