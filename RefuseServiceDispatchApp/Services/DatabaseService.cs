using System.Net.Http.Json;
using RefuseServiceDispatchApp.Models;

namespace RefuseServiceDispatchApp.Services;

public class DatabaseService
{
    private readonly HttpClient client = new()
    {
        BaseAddress = new Uri("https://guntherrefusedispatchapi.azurewebsites.net/DispatchRecord/")
    };

    public async Task CreateDispatchRecordAsync(DispatchRecord record)
    {
        try
        {
            await client.PostAsJsonAsync<DispatchRecord>("AddDispatchRecord", record);
        }
        catch
        {
            return;
        }
    }

    public async Task<List<Employee>> GetEmployeesAsync()
    {
        try
        {
            return await client.GetFromJsonAsync<List<Employee>>("AllEmployees") ?? new List<Employee>();
        }
        catch
        {
            return new List<Employee>();
        }
    }

    public async Task<List<Truck>> GetTrucksAsync()
    {
        try
        {
            return await client.GetFromJsonAsync<List<Truck>>("AllTrucks") ?? new List<Truck>();
        }
        catch
        {
            return new List<Truck>();
        }
    }

    public async Task<List<DispatchRecord>> GetTodaysDispatchRecordAsync()
    {
        try
        {
            return await client.GetFromJsonAsync<List<DispatchRecord>>("AllDispatchRecordsFromToday") ?? new List<DispatchRecord>();
        }
        catch
        {
            return new List<DispatchRecord>();
        }
    }
}

