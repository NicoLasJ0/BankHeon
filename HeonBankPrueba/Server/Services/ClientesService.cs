using Dapper;
using HeonBankPrueba.Shared;
using Microsoft.Data.SqlClient;

namespace HeonBankPrueba.Server.Services
{
    public class ClientesService
    {
        private string _connectionString;
        public ClientesService(IConfiguration configuration) 
        {
            this._connectionString = configuration.GetConnectionString("localdb");
        }

        public async Task<List<dynamic>> GetClientes(int? cliId) 
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"EXEC Sp_GetClients";

                var result = await db.QueryAsync<dynamic>(sql);

                return result.ToList();
            }
        }

        public async Task<dynamic> GetCliente(int cliId) 
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"EXEC Sp_GetClients @CliId";

                var parameters = new { @CliId= cliId };

                var result = await db.QueryFirstAsync<dynamic>(sql, parameters);

                return result;
            }
        }

        public async Task<dynamic> SaveClientes(Clientes cliente) 
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"EXEC Sp_SaveOrUpdateClients @CliId, @TpiId, @CliCodigo, @CliNombres, @CliApellidos, @CliEstadoActivo;";

                var parameters = new { 
                    @CliId= cliente.CliId,
                    @TpiId= cliente.TpiId,
                    @CliCodigo= cliente.CliCodigo,
                    @CliNombres = cliente.CliNombres, 
                    @CliApellidos = cliente.CliApellidos,
                    @CliEstadoActivo= cliente.CliEstadoActivo
                };
                var result= await db.QueryFirstAsync<dynamic>(sql, parameters);

                return result;
            }
        }

        public async Task DeleteClientes(int CliId) 
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"EXEC Sp_DeleteClients @CliId";
                var parameters = new
                {
                    @CliId= CliId
                };
                var result = await db.QueryFirstOrDefaultAsync<dynamic>(sql, parameters);
                
            }
        }

    }
}
