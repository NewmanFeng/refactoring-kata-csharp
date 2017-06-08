using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringKata
{
    public class Order
    {
        private readonly int id;
        private readonly List<Product> _products = new List<Product>();

        public Order(int id)
        {
            this.id = id;
        }

        public int GetOrderId()
        {
            return id;
        }

        public int GetProductsCount()
        {
            return _products.Count;
        }

        public Product GetProduct(int j)
        {
            return _products[j];
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public List<Product> GetProductLists()
        {
            return _products;
        }

        public string GetProductsFormat()
        {
            if (!_products.Any())
                return "[]";
            var products = string.Join(" ,", GetProductLists().Select(product =>
            {
                return product.ProductFormat();
            }).ToArray());

            return "[" + products + "]";
        }

        public string OrdersFormat()
        {
            var orderProperties = new Dictionary<string, object>()
            {
                {"id", GetOrderId()},
                {"products", GetProductsFormat()}
            };

            var orders = orderProperties.Select(orderProperty =>
            {
                return string.Format("\"{0}\": {1}", orderProperty.Key, orderProperty.Value);
            }).ToArray();
            return "{" + string.Join(", ", orders) + "}";
        }
    }
}