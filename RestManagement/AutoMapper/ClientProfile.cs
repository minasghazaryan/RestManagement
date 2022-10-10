using AutoMapper;
using RestManagement.Data.ViewModel;
using RestManagement.DataAccess.Entities;
using RestManagement.Service.ServiceModels;
using RestManagement.ViewModel;

namespace RestManagement.AutoMapper
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientRegisterViewModel, ClientRegisterServiceModel>().ReverseMap();
            CreateMap<ClientRegisterServiceModel, Client>().ReverseMap();
            CreateMap<ClientRegisterServiceModel, AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
            CreateMap<EmployeeServiceModel, AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

            CreateMap<LoginViewModel, LoginServiceModel>();
            CreateMap<EmployeeViewModel, EmployeeServiceModel>().ReverseMap();
            CreateMap<EmployeeServiceModel, Employee>().ReverseMap();
            CreateMap<LoginResonseViewModel, LoginResponseServiceModel>().ReverseMap();

            CreateMap<OredrViewModel, OredrServiceModel>().ReverseMap();
            CreateMap<OredrServiceModel, Order>().ReverseMap();

            CreateMap<ProductSimpleServiceModel, ProductSimpleViewModel>().ReverseMap();


            CreateMap<ProductViewModel, ProductServiceModel>().ReverseMap();
            CreateMap<ProductServiceModel, Product>().ReverseMap();


        }
    }
}
