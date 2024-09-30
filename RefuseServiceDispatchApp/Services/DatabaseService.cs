using Dapper;
using MySqlConnector;
using RefuseServiceDispatchApp.Models;

namespace RefuseServiceDispatchApp.Services;

public class DatabaseService
{
    private async Task<IEnumerable<T>?> QueryDatabaseAsync<T>(string sql)
    {
        var builder = new MySqlConnectionStringBuilder
        {
            Server = "mysqlmssa.mysql.database.azure.com",
            Database = "guntherrefuse",
            UserID = "applogin",
            Password = "T3stP@ssw0rd",
            SslMode = MySqlSslMode.Required,
        };

        var connection = new MySqlConnection(builder.ConnectionString);

        await connection.OpenAsync();

        var results = await connection.QueryAsync<T>(sql);

        return results;
    }

    public async Task CreateDispatchRecordAsync(DispatchRecord record)
    {
        string sql = "INSERT INTO dispatchrecords (DispatchDate, ServiceArea, Route, TruckNumber, Driver, HelperOne, HelperTwo, RefuseType) " +
                    $"VALUES ('{record.Date.Year}-{record.Date.Month}-{record.Date.Day}', '{record.ServiceArea}', '{record.Route}', '{record.TruckNumber}', '{record.Driver}', '{record.HelperOne}', '{record.HelperTwo}', '{record.RefuseType}');";

        await QueryDatabaseAsync<DispatchRecord>(sql);
    }

    public async Task<List<Employee>> GetEmployeesAsync()
    {
        var results = await QueryDatabaseAsync<Employee>("SELECT * From employees");

        return results.ToList<Employee>() ?? new List<Employee>();
    }

    public async Task<List<Truck>> GetTrucksAsync()
    {
        var results = await QueryDatabaseAsync<Truck>("SELECT * FROM trucks");

        return results?.ToList() ?? new List<Truck>();
    }

    public async Task<List<DispatchRecord>> GetTodaysDispatchRecordAsync()
    {
        var results = await QueryDatabaseAsync<DispatchRecord>($"SELECT * FROM dispatchrecords WHERE DispatchDate = '{DateTime.Today.Date.Year}-{DateTime.Today.Date.Month}-{DateTime.Today.Date.Day}'");

        return results?.ToList() ?? new List<DispatchRecord>();
    }
}

