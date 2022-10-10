using RestManagement.DataAccess.Entities;
using RestManagement.Service.ServiceModels;
using RestManagement.Service.Services;

namespace RestManagement.Service.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<List<string>> GetMenuAsync();
        Task CreateAsync(ProductServiceModel product);
        Task DeleteAsync(int id);
        Task UpdateAsync(ProductServiceModel product);
    }
}