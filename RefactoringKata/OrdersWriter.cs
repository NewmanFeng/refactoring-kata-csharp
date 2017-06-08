namespace RefactoringKata
{
    public class OrdersWriter
    {
        private Orders _orders;

        public OrdersWriter(Orders orders)
        {
            _orders = orders;
        }

        public Orders Orders
        {
            set { _orders = value; }
            get { return _orders; }
        }

        public string GetContents()
        {
            return _orders.ToFormat();
        }
    }
}