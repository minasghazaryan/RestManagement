using RestManagement.Service.ServiceModels;

namespace RestManagement.Service.Services.Interfaces
{
    public interface IClientService
    {
        Task CreateClientAsync(ClientRegisterServiceModel serviceModel);
    }
}
