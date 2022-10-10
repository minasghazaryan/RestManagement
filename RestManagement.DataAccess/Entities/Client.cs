namespace RestManagement.DataAccess.Entities
{
    public class Client : BaseEntity
    {
        public Client()
        {
            Employees = new HashSet<Employee>();
        }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public AppUser User { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }    
    }
}
