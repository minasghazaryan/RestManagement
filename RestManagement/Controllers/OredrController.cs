using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestManagement.DataAccess.Entities;
using RestManagement.Service.Interfaces;
using RestManagement.Service.ServiceModels;
using RestManagement.Service.Services.Interfaces;
using RestManagement.ViewModel;

namespace RestManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OredrController : BaseController
    {
        private readonly IOrderService _orderSevice;

        public OredrController
            (
                IOrderService orderSevice,
                IMapper mapper
            ) : base(mapper)
        {
            _orderSevice = orderSevice;
        }

        [HttpPost("CreateOrder")]
        public async Task<bool> CreateOrderAsync(OredrViewModel viewModel)
        {
            var serviceModel = _mapper.Map<OredrServiceModel>(viewModel);
            return await Execute(async () => await _orderSevice.CreateOrderAsync(serviceModel));
        }
    }
}
