using Motor_depot.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_depot.Factories
{
    internal abstract class OrderFactory
    {
        public abstract Order GetOrder();
    }
}
