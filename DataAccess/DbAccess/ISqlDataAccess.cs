
namespace DataAccess.DbAccess
{
  public interface ISqlDataAccess
  {
    Task<IEnumerable<T>> LoadData<T, U>(string procedure, U parameters, string connectionName = "Default");
    Task SaveData<T>(string procedure, T parameters, string connectionName = "Default");
  }
}