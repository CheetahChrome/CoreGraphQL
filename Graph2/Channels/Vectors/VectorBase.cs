using Graph2.Channels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graph2.Channels.Vectors
{
    public class VectorBase
    {
        public IDBAccess Connection { get; set; }
        public VectorBase(IDBAccess connection) => Connection = connection;
    }
}
