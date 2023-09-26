using Dapper;
using Microsoft.Data.SqlClient;

namespace HeonBankPrueba.Server.Services
{
    public class FormaPagoService
    {
        private readonly string _connectionString;
        public FormaPagoService(IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString("localdb");
        }

        public async Task<dynamic> GetFormasPago() 
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT * FROM FormaPago";

                var result= await db.QueryAsync<dynamic>(sql);

                return result;
            }
        }
    }
}
