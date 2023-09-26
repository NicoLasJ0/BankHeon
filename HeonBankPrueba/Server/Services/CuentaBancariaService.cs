using Dapper;
using HeonBankPrueba.Shared;
using Microsoft.Data.SqlClient;

namespace HeonBankPrueba.Server.Services
{
    public class CuentaBancariaService
    {
        private readonly string _connectionString;
        public CuentaBancariaService(IConfiguration configuration) 
        {
            this._connectionString = configuration.GetConnectionString("localdb");
        }

        public async Task<dynamic> GetCuentasBancarias()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"EXEC Sp_GetCuentaBancaria";

                var result = await db.QueryAsync<dynamic>(sql);

                return result.ToList();
            }
        }

        public async Task<dynamic> GetCuentaBancaria(int CubId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"EXEC Sp_GetCuentaBancaria @CubId";

                var parameters = new
                {
                    @CubId= CubId
                };

                var result= await db.QueryFirstAsync<dynamic>(sql, parameters);

                return result;
            }
        }

        

        public async Task<dynamic> SaveCuentaBancaria(CuentaBancaria cuentaBancaria)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"EXEC Sp_SaveOrUpdateCuentaBancaria @CubId, @TpcId, @BcoId, @CliId, @CubCodigo, @CubDescripcion, @CubEstadoActivo";

                var parameters = new 
                {
                    @CubId= cuentaBancaria.CubId,
                    @TpcId= cuentaBancaria.TpcId,
                    @BcoId= cuentaBancaria.BcoId,
                    @CliId= cuentaBancaria.CliId,
                    @CubCodigo= cuentaBancaria.CubCodigo,
                    @CubDescripcion = cuentaBancaria.CubDescripcion,
                    @CubEstadoActivo= cuentaBancaria.CubEstadoActivo
                };

                var result= await db.QueryFirstAsync<dynamic>(sql, parameters);

                return result;
            }
        }

        public async Task DeleteCuentaBancaria(int cubId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"EXEC Sp_DeleteCuentaBancaria @CubId";

                var parameters = new 
                { 
                    @CubId= cubId
                };

                await db.QueryFirstOrDefaultAsync<dynamic>(sql, parameters);
            }
        }
    }

    
}
