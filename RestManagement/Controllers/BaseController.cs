using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace RestManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;
        public BaseController
            (
                IMapper mapper
            )
        {
            _mapper = mapper;
        }

        protected async Task<TViewModel> Execute<TViewModel, TServiceModel>(Func<Task<TServiceModel>> action)
        {
            var serviceModel = await action();
            return _mapper.Map<TViewModel>(serviceModel);
        }

        protected async Task<T> Execute<T>(Func<Task<T>> action)
        {
            return await action();
        }
        
        protected Task Execute(Func<Task> action)
        {
            return action();
        }
    }

}
