using Graph2.Channels.Vectors;
using Graph2.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graph2.GraphQL.Types
{
public class CustomerType : ObjectGraphType<Customer>
{
    public CustomerType(OrderVector ordVector)
    {
        Field(t => t.AccountOpenedDate);
        Field(t => t.CustomerID);
        Field(t => t.CustomerName).Description("The combined name of the customer");
        Field(t => t.BillToCustomerID);
        Field(t => t.CustomerCategoryID);
        Field(t => t.PrimaryContactPersonID);
        Field(t => t.DeliveryMethodID);
        Field(t => t.DeliveryCityID);
        Field(t => t.PostalCityID);
        Field(t => t.CreditLimit);
        Field(t => t.StandardDiscountPercentage);
        Field(t => t.IsStatementSent);
        Field(t => t.IsOnCreditHold);
        Field(t => t.PaymentDays);
        Field(t => t.PhoneNumber);
        Field(t => t.FaxNumber);
        Field(t => t.DeliveryRun);
        Field(t => t.RunPosition);
        Field(t => t.WebsiteURL);
        Field(t => t.DeliveryAddressLine1);
        Field(t => t.DeliveryAddressLine2);
        Field(t => t.DeliveryPostalCode);
        Field(t => t.PostalAddressLine1);
        Field(t => t.PostalAddressLine2);
        Field(t => t.PostalPostalCode);
        Field(t => t.LastEditedBy);
        Field(t => t.ValidFrom);
        Field(t => t.ValidTo);

       Field<ListGraphType<OrderType>>("orders",
               resolve: context => ordVector.GetAllForCustomer(context.Source.CustomerID)

    );
        }
}
}
