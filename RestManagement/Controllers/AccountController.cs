using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestManagement.Data.ViewModel;
using RestManagement.Service.Interfaces;
using RestManagement.Service.ServiceModels;
using RestManagement.ViewModel;

namespace RestManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController
            (
                IAccountService accountService,
                IMapper mapper
            ) : base(mapper)
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<LoginResonseViewModel> LoginAsync([FromBody] LoginViewModel model)
        {
            var serviceModel = _mapper.Map<LoginServiceModel>(model);
            return await Execute<LoginResonseViewModel, LoginResponseServiceModel>(async () => await _accountService.LoginAsync(serviceModel));
        }
    }
}
