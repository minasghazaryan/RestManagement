using RestManagement.Service.ServiceModels;

namespace RestManagement.Service.Interfaces
{
    public interface IAccountService
    {
        Task<string> CreateUserAsync(BaseRegisterServiceModel client);
        Task<LoginResponseServiceModel> LoginAsync(LoginServiceModel client);
    }
}
