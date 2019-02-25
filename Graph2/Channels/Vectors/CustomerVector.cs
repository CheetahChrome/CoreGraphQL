using Graph2.Channels.Interfaces;
using Graph2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graph2.Channels.Vectors
{
    public class CustomerVector : VectorBase
    {
        public CustomerVector(IDBAccess connection) : base(connection) { }

        public async Task<string> GetAllJSON() => await Connection.AcquireJSON("[JSON].GetCustomers");

        
   //     public async Task<string> GetAllModels() => await Task.FromResult("GraphQL TBD");
        public async Task<List<Customer>> GetAllModels() => await Connection.AcquireModels<Customer>("[JSON].GetCustomers");

    }
}
