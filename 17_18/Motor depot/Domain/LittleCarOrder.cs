using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_depot.Domain
{
    internal class LittleCarOrder : Order
    {
        public string _name;

        public LittleCarOrder(uint orderID, uint carCarring, uint carSpeed)
        {
            _orderID = orderID;
            _carCarring = carCarring;
            _carSpeed = carSpeed;

            _name = "Little car order";
        }

        public override string Name => _name;
    }
}
