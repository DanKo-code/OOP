using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_depot.Domain
{
    internal class MediumCarOrder : Order
    {
        public string _name;

        public MediumCarOrder(uint orderID, uint carCarring, uint carSpeed)
        {
            _orderID = orderID;
            _carCarring = carCarring;
            _carSpeed = carSpeed;

            _name = "Medium car order";
        }

        public override string Name => _name;
    
    }
}
