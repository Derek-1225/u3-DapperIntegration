using Dapper;
namespace Orders.Api.models.dapper
{
    public interface IDapperService
    {
        Task<DapperResponse> ExecuteQueryAsync<T>(string query, StoredProcedureInf parameters, string connectionId, bool hasArray = false);
        Task<DapperResponse> ExecuteStoredProcedureAsync<T>(StoredProcedureInf qData, DynamicParameters? parameters = null, bool hasArray = false);
    }
}