using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using RestManagement.DataAccess.Entities;
using RestManagement.DataAccess;
using RestManagement.Service.Services.Interfaces;
using RestManagement.Shared.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestManagement.Service.ServiceModels;
using RestManagement.Service.Interfaces;
using RestManagement.Shared.Roles;

namespace RestManagement.Service.Services
{
    public class ClientService : BaseService, IClientService
    {
        private readonly IAccountService _accountService;
        public ClientService
            (
                AppDbContext context,
                IAccountService accountService,
                IMapper mapper,
                ICurrentCallContext currentCallContext
            ) : base(context, mapper, currentCallContext)
        {
            _accountService = accountService;
        }

        public async Task CreateClientAsync(ClientRegisterServiceModel serviceModel)
        {
            serviceModel.Role = RoleNames.Client;
            var userId = await _accountService.CreateUserAsync(serviceModel);
            var client = _mapper.Map<Client>(serviceModel);
            client.UserId = userId;
            await _context.Clients.AddAsync(client);
            await SaveChangesAsync(client);
        }
    }
}
