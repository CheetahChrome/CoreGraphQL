using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Graph2.Channels.Interfaces
{
public interface IDBAccess
{
    Task<string> AcquireJSON(string sproc, params SqlParameter[] parameters);

    Task<List<T>> AcquireModels<T>(string sproc, params SqlParameter[] parameters);

}
}
