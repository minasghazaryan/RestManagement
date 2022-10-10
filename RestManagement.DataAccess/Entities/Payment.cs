using RestManagement.Shared.Enums;

namespace RestManagement.DataAccess.Entities
{
    public class Payment : BaseEntity
    {
        public int PaymentId { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal Amount { get; set; }
        public int OredrId { get; set; }
        public virtual Order Order { get; set; }
    }
}
