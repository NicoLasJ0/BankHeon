using Dapper;
using Microsoft.Data.SqlClient;

namespace HeonBankPrueba.Server.Services
{
    public class BancosService
    {
        private readonly string _connString;
        public BancosService(IConfiguration configuration) 
        {
            this._connString = configuration.GetConnectionString("localdb");
        }

        public async Task<dynamic> GetBancos() 
        {
            using (var db = new SqlConnection(_connString))
            {

                var sql = "SELECT * FROM Bancos";
                var result= await db.QueryAsync<dynamic>(sql);

                return result.ToList();
            }
        }

        public async Task<dynamic> GetBanco(int bcoId) 
        {
            using (var db= new SqlConnection(_connString))
            {
                var sql1 = "SELECT * FROM Bancos WHERE BcoId= @BcoId";
                var parameters = new
                {
                    @BcoId = bcoId
                };
                var res = await db.QueryFirstAsync<dynamic>(sql1, parameters);

                return res;
            }
        }
    }
}
