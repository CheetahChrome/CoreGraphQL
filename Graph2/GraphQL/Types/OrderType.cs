using Graph2.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graph2.GraphQL.Types
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType()
        {
            Field(t => t.OrderID);
            Field(t => t.CustomerID);
            Field(t => t.SalespersonPersonID);
            Field(t => t.PickedByPersonID);
            Field(t => t.ContactPersonID);
            Field(t => t.OrderDate);
            Field(t => t.ExpectedDeliveryDate);
            Field(t => t.CustomerPurchaseOrderNumber);
            Field(t => t.IsUndersupplyBackordered);
            Field(t => t.PickingCompletedWhen);
            Field(t => t.LastEditedBy);
            Field(t => t.LastEditedWhen);
        }

    }
}
