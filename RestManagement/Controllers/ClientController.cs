using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestManagement.Service.ServiceModels;
using RestManagement.Service.Services.Interfaces;
using RestManagement.Shared.Roles;
using RestManagement.ViewModel;

namespace RestManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly IClientService _clientService;
        public ClientController
            (
                IClientService clientService,
                IMapper mapper
            ) : base(mapper)
        {
            _clientService = clientService;
        }

        [HttpPost("Register")]
        public async Task RegisterAsync(ClientRegisterViewModel viewModel)
        {
            var model = _mapper.Map<ClientRegisterServiceModel>(viewModel);
            await Execute(() => _clientService.CreateClientAsync(model));
        }
    }
}
