namespace RestManagement.DataAccess.Entities
{
    public class ProductOrder : BaseEntity
    {
        public int ProductOrderId { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}