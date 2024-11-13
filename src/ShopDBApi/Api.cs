using DataAccess.Data;
using DataAccess.Model;

namespace ShopDBApi;

public static class Api
{
  public static void ConfigureApi(this WebApplication app)
  {
    app.MapGet("/Customers", GetCustomers);
    app.MapGet("/Customers/{id}", GetCustomer);
    app.MapPost("/Customers", InsertCustomer);
    app.MapPut("/Customers", UpdateCustomer);
    app.MapDelete("/Customers", DeleteCustomer);
  }

  private static async Task<IResult> GetCustomers(ICustomerData data)
  {
    try
    {
      return Results.Ok(await data.GetCustomers());
    }
    catch (Exception e)
    {
      return Results.Problem(e.Message);
    }
  }

  private static async Task<IResult> GetCustomer(int id, ICustomerData data)
  {
    try
    {
      var customer = await data.GetCustomer(id);

      if (customer == null)
      {
        return Results.NotFound("Customer not found");
      }

      return Results.Ok(customer);
    }
    catch (Exception e)
    {
      return Results.Problem(e.Message);
    }
  }

  private static async Task<IResult> InsertCustomer(Customer customer, ICustomerData data)
  {
    try
    {
      await data.InsertCustomer(customer);

      return Results.Ok("Customer created successfully");
    }
    catch (Exception e)
    {
      return Results.Problem(e.Message);
    }
  }

  private static async Task<IResult> UpdateCustomer(Customer customer, ICustomerData data)
  {
    try
    {
      await data.UpdateCustomer(customer);

      return Results.Ok("Customer updated successfully");
    }
    catch (Exception e)
    {
      return Results.Problem(e.Message);
    }
  }

  private static async Task<IResult> DeleteCustomer(int id, ICustomerData data)
  {
    try
    {
      await data.DeleteCustomer(id);

      return Results.Ok("Customer deleted successfully");
    }
    catch (Exception e)
    {
      return Results.Problem(e.Message);
    }
  }
}
