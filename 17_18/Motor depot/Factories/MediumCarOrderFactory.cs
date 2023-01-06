using Motor_depot.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_depot.Factories
{
    internal class MediumCarOrderFactory : OrderFactory
    {
        public uint _orderID;
        public uint _carCarring;
        public uint _carSpeed;

        public MediumCarOrderFactory(uint orderID, uint carCarring, uint carSpeed)
        {
            _orderID = orderID;
            _carCarring = carCarring;
            _carSpeed = carSpeed;
        }

        public override Order GetOrder()
        {
            MediumCarOrder order = new(_orderID, _carCarring, _carSpeed);

            return order;
        }
    }
}
