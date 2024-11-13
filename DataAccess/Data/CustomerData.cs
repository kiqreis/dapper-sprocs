using DataAccess.DbAccess;
using DataAccess.Model;

namespace DataAccess.Data;

public class CustomerData(ISqlDataAccess dataAccess) : ICustomerData
{
  public Task<IEnumerable<Customer>> GetCustomers() => dataAccess.LoadData<Customer, dynamic>("dbo.spCustomer_GetAll", new { });

  public async Task<Customer> GetCustomer(int id)
  {
    var customers = await dataAccess.LoadData<Customer, dynamic>("dbo.spCustomer_Get", new { Id = id });

    return customers.FirstOrDefault()!;
  }

  public Task InsertCustomer(Customer customer) => dataAccess.SaveData("dbo.spCustomer_Insert", new { customer.FirstName, customer.LastName });

  public Task UpdateCustomer(Customer customer) => dataAccess.SaveData("dbo.spCustomer_Update", customer);

  public Task DeleteCustomer(int id) => dataAccess.SaveData("dbo.spCustomer_Delete", new { @Id = id });
}
