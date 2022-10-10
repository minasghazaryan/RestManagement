namespace RestManagement.DataAccess.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public bool InMenue { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
