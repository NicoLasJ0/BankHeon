using Azure.Core;
using Dapper;
using HeonBankPrueba.Shared;
using Microsoft.Data.SqlClient;

namespace HeonBankPrueba.Server.Services
{
    public class TransaccionService
    {
        private readonly string _stringConnection;
        public TransaccionService(IConfiguration configuration) 
        {
            this._stringConnection = configuration.GetConnectionString("localdb");
        }

        public async Task<dynamic> GetTransacciones()
        {
            using (var db = new SqlConnection(_stringConnection))
            {
                var sql = @"EXEC Sp_GetTransactions";

                var result= await db.QueryAsync<dynamic>(sql);

                return result.ToList();
            }
        }

        public async Task<dynamic> GetTransaccion(int trnsId)
        {
            using (var db = new SqlConnection(_stringConnection))
            {
                var sql = @"EXEC Sp_GetTransactions @TrnsId";

                var parameters = new
                {
                    @TrnsId= trnsId
                };

                var result= await db.QueryFirstAsync<dynamic>(sql, parameters);

                return result;
            }
        }

        public async Task<dynamic> SaveTransaccion(Transaccion transaccion)
        {
            using (var db = new SqlConnection(_stringConnection))
            {
                var sql = @"EXEC Sp_SaveOrUpdateTransactions @TrnsId, @CliId, @CubId, @TpoTrnsId, @FrmPgoId, @TrnsMonto, @TrnsEstadoActivo";

                var parameters = new 
                {
                    @TrnsId= transaccion.TrnsId,
                    @CliId= transaccion.CliId,
                    @CubId= transaccion.CubId,
                    @TpoTrnsId= transaccion.TpoTrnsId,
                    @FrmPgoId= transaccion.FrmPgoId,
                    @TrnsMonto= transaccion.TrnsMonto,
                    @TrnsEstadoActivo= transaccion.TrnsEstadoActivo
                };

                var result = await db.QueryFirstAsync<dynamic>(sql, parameters);

                return result;
            }
        }

        public async Task DeleteTransaccion(int trnsId)
        {
            using (var db = new SqlConnection(_stringConnection))
            {
                var sql = @"EXEC Sp_DeleteTransactions @TrnsId";

                var parameters = new 
                { 
                    @TrnsId= trnsId
                };

                await db.QueryFirstOrDefaultAsync<dynamic>(sql, parameters);

            }

        }
    }
}
