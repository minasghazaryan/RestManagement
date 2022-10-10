using RestManagement.Data.Models;
using RestManagement.Shared.Enums;

namespace RestManagement.ViewModel
{
    public class EmployeeViewModel : BaseRegisterViewModel
    {
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public EmployeePossitionType Possition { get; set; }
    }
}
