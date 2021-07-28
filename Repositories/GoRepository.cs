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
    public class GoRepository : IGoRepository
    {
        private SqlConfiguration _connectionString;

        public GoRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<GoUser> AutohorizeGoUser(string username, string key)
        {
            GoUser u;
            try
            {
                var db = dbConnection();
                var sql = @"SELECT usuario as user, pass as key, 'Autheticated' as status, 1 as authorized
                            FROM public.funcionarios
                            where usuario = @usuario
                            and pass = @key;";

                u = await db.QueryFirstOrDefaultAsync<GoUser>(sql, new { usuario = username, key = key });

                if (u == null)
                {
                    u = new GoUser { authorized = false, user = username, status = "Not Authenticated" };
                }

                return u;

            }
            catch (Exception ex)
            {
                return null;
            }


        }
    }
}

