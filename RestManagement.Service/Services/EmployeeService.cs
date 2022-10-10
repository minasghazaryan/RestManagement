using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestManagement.DataAccess;
using RestManagement.DataAccess.Entities;
using RestManagement.Service.Interfaces;
using RestManagement.Service.ServiceModels;
using RestManagement.Service.Services.Interfaces;
using RestManagement.Shared.Enums;
using RestManagement.Shared.Roles;
using System.Net.Http;
using System.Security.Claims;

namespace RestManagement.Service.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IAccountService _accountService;


        public EmployeeService
           (
               AppDbContext context,
               IAccountService accountService,
               IMapper mapper,
               ICurrentCallContext currentCallContext
           ) : base(context, mapper, currentCallContext)
        {
            _accountService = accountService;
        }

        public async Task AddAsync(EmployeeServiceModel serviceModel)
        {
            switch (serviceModel.Possition)
            {
                case EmployeePossitionType.Waiter:
                    serviceModel.Role = RoleNames.Waiter;
                    break;

                case EmployeePossitionType.Manager:
                    serviceModel.Role = RoleNames.Manager;
                    break;

                default:
                    throw new ArgumentException($"Possition value only Waiter or Manager");
            }
            var userId = await _accountService.CreateUserAsync(serviceModel);
            var employee = _mapper.Map<Employee>(serviceModel);
            employee.UserId = userId;
            ;
            employee.ClientId = await _context.Clients.Where(item => item.UserId == _currentCallContext.UserId)
                                                        .Select(item => item.ClientId)
                                                        .SingleAsync();
            await _context.Employees.AddAsync(employee);
            await SaveChangesAsync(employee);
        }

        public async Task UpdateAsync(EmployeeServiceModel serviceModel)
        {
            var employee = _context.Employees.SingleOrDefault(item => item.EmployeeId == serviceModel.EmployeeId.Value);

            _mapper.Map(serviceModel, employee);

            await SaveChangesAsync(employee,EntityState.Modified);
        }
    }
}
