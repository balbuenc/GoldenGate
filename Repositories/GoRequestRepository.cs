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
    public class GoRequestRepository : IGoRequestRepository
    {

        private SqlConfiguration _connectionString;

        public GoRequestRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> InsertGoRequest(int id_funcionario, DateTime fecha, int id_estado, string razon_social, string ruc, string telefono1, string telefono2, string email, string direccion, string representante, string cargo, string tipo)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO public.solicitudes_proveedor
                        (id_funcionario, fecha, id_estado, razon_social, ruc, telefono1, email, direccion, telefono2, representante, cargo, tipo)
                        VALUES(@id_funcionario, @fecha, @id_estado, @razon_social, @ruc, @telefono1, @email, @direccion, @telefono2, @representante, @cargo, @tipo);";

            GoRequest r = new GoRequest();

            r.id_funcionario = id_funcionario;
            r.fecha = DateTime.Now;
            r.id_estado = 1;
            r.ruc = ruc;
            r.razon_social = razon_social;
            r.telefono1 = telefono1;
            r.telefono2 = telefono2;
            r.email = email;
            r.direccion = direccion;
            r.representante = representante;
            r.cargo = cargo;
            r.tipo = tipo;

            var result = await db.ExecuteAsync(sql, new
            {
                r.id_funcionario,
                r.fecha,
                r.id_estado,
                r.ruc,
                r.razon_social,
                r.telefono1,
                r.telefono2,
                r.email,
                r.direccion,
                r.representante,
                r.cargo,
                r.tipo
            }
            );

            return result > 0;
        }
    }
}
