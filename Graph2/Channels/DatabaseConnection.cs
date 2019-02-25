using Graph2.Channels.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SQLJSON.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;



namespace Graph2.Channels
{
public class DatabaseConnection : IDBAccess
{
    IConfiguration Config { get; set; }

    public DatabaseConnection(IConfiguration config) => Config = config;

    public async Task<string> AcquireJSON(string sproc, params SqlParameter[] parameters)
    {
        string result = string.Empty;

        var connection = Config.GetConnectionString("WWIConnection");

        using (SqlConnection conn = new SqlConnection(connection))
        {
            conn.Open();

            using (var cmd = new SqlCommand(sproc, conn)
                        { CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 600 })
            {
                if (parameters?.Any() ?? false)
                    cmd.Parameters.AddRange(parameters);

                var reader = await cmd.ExecuteJsonReaderAsync();

                result = await reader.ReadAllAsync();
            }
        }

        return result;
    }

    public async Task<List<T>> AcquireModels<T>(string sproc, params SqlParameter[] parameters)
    {
        var response = await AcquireJSON(sproc, parameters);

        return string.IsNullOrWhiteSpace(response) 
                        ? null 
                        : JsonConvert.DeserializeObject<List<T>>(response); 
    }

}
}
