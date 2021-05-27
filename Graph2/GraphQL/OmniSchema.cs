using Graph2.GraphQL.Queries;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graph2.GraphQL
{
    public class OmniSchema : Schema
    {
        public OmniSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<WorldWideQuery>();
        }


    }
}
