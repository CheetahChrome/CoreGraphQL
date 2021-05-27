using Graph2.Channels.Vectors;
using Graph2.GraphQL.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graph2.GraphQL.Queries
{
    public class WorldWideQuery : ObjectGraphType
    {
        public WorldWideQuery(OrderVector oVector, CustomerVector cVector)
        {
            Field<ListGraphType<OrderType>>(
                "orders"
                , resolve: context => oVector.GetAllModels()
                );

            Field<ListGraphType<CustomerType>>(
                "customers"
                , resolve: context => cVector.GetAllModels()
                );

            Field<ListGraphType<CustomerType>>(
                 "customer",
                 "Get Customer By ID",
                 new QueryArguments(
                     new QueryArgument<IntGraphType> { Name = "customerID" }
                     )
                 , resolve: context => cVector.GetAllModels()
                                              .Result.Where(md => md.CustomerID == (int)context.Arguments["customerID"])

                 );


        }

    }
}
