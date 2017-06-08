using System.Collections.Generic;
using System.Linq;

namespace RefactoringKata
{
    public class Orders
    {
        private List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public int GetOrdersCount()
        {
            return _orders.Count;
        }

        public string OrdersFormat()
        {
            return string.Join(", ", _orders.Select(order =>
            {
                return order.OrdersFormat();
            }).ToArray());
        }

        public string ToFormat()
        {
            return string.Format("{{\"orders\": [{0}]}}", OrdersFormat());
        }
    }
}
