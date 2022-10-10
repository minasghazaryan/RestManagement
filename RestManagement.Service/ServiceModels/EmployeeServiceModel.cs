using RestManagement.Shared.Enums;

namespace RestManagement.Service.ServiceModels
{
    public class EmployeeServiceModel : BaseRegisterServiceModel
    {
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public EmployeePossitionType Possition { get; set; }
    }
}