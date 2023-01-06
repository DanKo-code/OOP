using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_depot.Domain
{
    internal abstract class Order
    {
        public abstract string Name { get; }

        public uint _orderID;
        public uint _carCarring;
        public uint _carSpeed;

    }
}
