using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestManagement.Service.Interfaces;
using RestManagement.Service.ServiceModels;
using RestManagement.Service.Services.Interfaces;
using RestManagement.Shared.Roles;
using RestManagement.ViewModel;

namespace RestManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController
            (
                IProductService productService,
                IMapper mapper
            ) : base(mapper)
        {
            _productService = productService;
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleNames.Client},{RoleNames.Manager}")]
        public async Task AddProductAsync(ProductViewModel model)
        {
            var serviceModel = _mapper.Map<ProductServiceModel>(model);
            await Execute(async () => await _productService.CreateAsync(serviceModel));
        }
    }
}