using Dapper;
using MySqlConnector;
using RefuseServiceDispatchApp.Models;

namespace RefuseServiceDispatchApp.Services;

public class DatabaseService
{
    public async Task CreateDispatchRecord(DispatchRecord record)
    {
        var builder = new MySqlConnectionStringBuilder
        {
            Server = "mysqlmssa.mysql.database.azure.com",
            Database = "guntherrefuse",
            UserID = "applogin",
            Password = "T3stP@ssw0rd",
            SslMode = MySqlSslMode.Required,
        };

        using (var connection = new MySqlConnection(builder.ConnectionString))
        {
            await connection.OpenAsync();

            string sql = "INSERT INTO dispatchrecords (DispatchDate, ServiceArea, Route, TruckNumber, Driver, HelperOne, HelperTwo, RefuseType) " +
                        $"VALUES ('{record.Date.Year}-{record.Date.Month}-{record.Date.Day}', '{record.ServiceArea}', '{record.Route}', '{record.TruckNumber}', '{record.Driver}', '{record.HelperOne}', '{record.HelperTwo}', '{record.RefuseType}')";

            connection.Execute(sql);
        }

    }
}

