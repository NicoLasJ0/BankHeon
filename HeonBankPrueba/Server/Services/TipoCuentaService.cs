using Microsoft.Data.SqlClient;
using Dapper;

namespace HeonBankPrueba.Server.Services
{
    public class TipoCuentaService
    {
        private readonly string _connString;
        public TipoCuentaService(IConfiguration configuration)
        {
            this._connString = configuration.GetConnectionString("localdb");
        }

        public async Task<dynamic> GetTipoCuentas()
        {
            using (var db = new SqlConnection(_connString))
            {

                var sql = "SELECT * FROM TipoCuenta";
                var result = await db.QueryAsync<dynamic>(sql);

                return result.ToList();
            }
        }

        public async Task<dynamic> GetTipoCuenta(int tpcId)
        {
            using (var db = new SqlConnection(_connString))
            {
                var sql1 = "SELECT * FROM TipoCuenta WHERE TpcId= @TpcId";
                var parameters = new
                {
                    @TpcId = tpcId
                };
                var res = await db.QueryFirstAsync<dynamic>(sql1, parameters);

                return res;
            }
        }
    }
}
