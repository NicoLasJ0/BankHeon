using Dapper;
using Microsoft.Data.SqlClient;

namespace HeonBankPrueba.Server.Services
{
    public class TipoTransaccionService
    {
        private readonly string _connectionString;
        public TipoTransaccionService(IConfiguration configuration) 
        {
            this._connectionString = configuration.GetConnectionString("localdb");
        }

        public async Task<dynamic> GetTipoTransaccion() 
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT * FROM TipoTransaccion";
                
                var result= await db.QueryAsync<dynamic>(sql);

                return result.ToList();
            }
        }

    }
}
