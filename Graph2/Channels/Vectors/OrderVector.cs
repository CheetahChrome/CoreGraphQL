using Graph2.Channels.Interfaces;
using Graph2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graph2.Channels.Vectors
{
    public class OrderVector : VectorBase
    {
        public OrderVector(IDBAccess connection) : base(connection) { }

        public async Task<string> GetAllJSON()
            => await Connection.AcquireJSON("[JSON].GetOrders");

        public async Task<List<Order>> GetAllModels()
                => await Connection.AcquireModels<Order>("[JSON].GetOrders");

        public async Task<List<Order>> GetAllForCustomer(int customerID)
                => await Connection.AcquireModels<Order>
                    ( "[JSON].GetOrders", 
                    new System.Data.SqlClient.SqlParameter("customerId", customerID));
    }
}
