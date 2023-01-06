using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_depot.Builder
{
    internal interface IOrdersDisplayBuilder
    {
        void BuildHeader();

        void BuildBody();

        void BuildFooter();

        OrdersDisplay GetReport();
    }
}
