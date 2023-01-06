using Motor_depot.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_depot.Builder
{
    internal class OrdersDisplayBuilder : IOrdersDisplayBuilder
    {
        private OrdersDisplay _ordersDisplay;

        private readonly IEnumerable<Domain.Order> _orders;

        public OrdersDisplayBuilder(IEnumerable<Domain.Order> orders)
        {
            _orders = orders;
            _ordersDisplay = new();
        }

        public void BuildHeader()
        {
            _ordersDisplay.Header =
                $"Orders display DATE: {DateTime.Now}\n";

            _ordersDisplay.Header +=
                "\n----------------------------------------------------------------------------------------------------\n";
        }

        public void BuildBody()
        {
            _ordersDisplay.Body =
                string.Join(Environment.NewLine,
                    _orders.Select(e =>
                    $"Order: {e.Name}\tID заказа: {e._orderID}\tГрузоподъемность: {e._carCarring}\tСкорость: {e._carSpeed}"));
        }

        public void BuildFooter()
        {
            _ordersDisplay.Footer =
                "\n----------------------------------------------------------------------------------------------------\n";

            _ordersDisplay.Footer +=
                $"\nTOTAL orders: {_orders.Count()}";
        }

        public OrdersDisplay GetReport()
        {
            OrdersDisplay employeeReport = _ordersDisplay;

            _ordersDisplay = new();

            return employeeReport;
        }
    }
}
