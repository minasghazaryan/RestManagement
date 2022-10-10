using RestManagement.Service.ServiceModels;

namespace RestManagement.Service.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task AddAsync(EmployeeServiceModel serviceModel);
        Task UpdateAsync(EmployeeServiceModel serviceModel);
    }
}
