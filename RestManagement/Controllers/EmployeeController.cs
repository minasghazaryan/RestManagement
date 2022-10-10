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
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController
            (
                IEmployeeService employeeService,
                IMapper mapper
            ) : base(mapper)
        {
            _employeeService = employeeService;
        }

        [HttpPost("Add")]
        [Authorize(Roles = RoleNames.Client)]
        public Task AddAsync(EmployeeViewModel viewModel)
        {
            var serviceModel = _mapper.Map<EmployeeServiceModel>(viewModel);
            return Execute(() => _employeeService.AddAsync(serviceModel));
        }

        [HttpPost("Update")]
        [Authorize(Roles = $"{RoleNames.Client},{RoleNames.Manager}")]
        public Task UpdateAsync(EmployeeViewModel viewModel)
        {
            var serviceModel = _mapper.Map<EmployeeServiceModel>(viewModel);
            return Execute(() => _employeeService.UpdateAsync(serviceModel));
        }
    }
}
