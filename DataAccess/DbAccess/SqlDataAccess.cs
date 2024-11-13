using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DataAccess.DbAccess;

public class SqlDataAccess(IConfiguration configuration) : ISqlDataAccess
{
  public async Task<IEnumerable<T>> LoadData<T, U>(string procedure, U parameters, string connectionName = "Default")
  {
    using IDbConnection connection = new SqlConnection(configuration.GetConnectionString(connectionName));

    return await connection.QueryAsync<T>(procedure, parameters, commandType: CommandType.StoredProcedure);
  }

  public async Task SaveData<T>(string procedure, T parameters, string connectionName = "Default")
  {
    using IDbConnection connection = new SqlConnection(configuration.GetConnectionString(connectionName));

    await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
  }
}
