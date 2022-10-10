namespace RestManagement.DataAccess.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
