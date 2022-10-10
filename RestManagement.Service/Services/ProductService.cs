using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RestManagement.DataAccess;
using RestManagement.DataAccess.Entities;
using RestManagement.Service.Interfaces;
using RestManagement.Service.ServiceModels;
using RestManagement.Service.Services.Interfaces;
using RestManagement.Shared.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestManagement.Service.Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService
            (
                AppDbContext context,
                IMapper mapper,
                ICurrentCallContext currentCallContext
            ) : base(context, mapper, currentCallContext)
        {
        }

        public async Task CreateAsync(ProductServiceModel product)
        {
            var entity = _mapper.Map<Product>(product);
            await _context.Products.AddAsync(entity);
            await SaveChangesAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var product = _context.Products.Where(x => x.ProductId == id).Single();
            await SaveChangesAsync(product, EntityState.Deleted);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<List<string>> GetMenuAsync()
        {
            var menu = await _context.Products.Select(x => x.ProductName).ToListAsync();
            return menu;
        }

        public async Task UpdateAsync(ProductServiceModel product)
        {
            var entity = _mapper.Map<Product>(product);
            _context.Products.Update(entity);
            await SaveChangesAsync(entity, EntityState.Modified);
        }
    }
}
