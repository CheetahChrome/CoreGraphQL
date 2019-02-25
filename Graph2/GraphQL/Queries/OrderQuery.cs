using Graph2.Channels.Vectors;
using Graph2.GraphQL.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graph2.GraphQL.Queries
{
public class OrderQuery : ObjectGraphType
{
    public OrderQuery(OrderVector vector)
    {
        Field<ListGraphType<OrderType>>(
            "orders"
            , resolve: context => vector.GetAllModels()
            );
    }
}
}
