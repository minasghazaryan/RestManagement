using RestManagement.Shared.Enums;

namespace RestManagement.DataAccess.Entities
{
    public class Employee : BaseEntity
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public AppUser User { get; set; }
        public string UserId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public EmployeePossitionType Possition { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
