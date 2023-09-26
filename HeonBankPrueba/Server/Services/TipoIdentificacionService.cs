using Dapper;
using HeonBankPrueba.Shared;
using Microsoft.Data.SqlClient;

namespace HeonBankPrueba.Server.Services
{
    public class TipoIdentificacionService
    {
        private readonly string _connectionString;
        public TipoIdentificacionService(IConfiguration configuration) 
        {
            this._connectionString = configuration.GetConnectionString("localdb");
        }

        public async Task<dynamic> GetTipoIdentificacion() 
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT * FROM TipoIdentificacion";
                
                var result= await db.QueryAsync<dynamic>(sql);

                return result.ToList();
            }
        }
    }
}
