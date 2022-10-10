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
using RestManagement.Shared.Enums;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace RestManagement.Service.Services
{
    public class OrderService : BaseService, IOrderService
    {
        

        public OrderService
           (
               AppDbContext context,
               IMapper mapper,
                 ICurrentCallContext currentCallContext
           ) : base(context, mapper, currentCallContext)
        {
        }

        public async Task<bool> CreateOrderAsync(OredrServiceModel serviceModel)
        {
            var employeeId = _context.Employees.Where(item => item.UserId == _currentCallContext.UserId).Select(item => item.EmployeeId).Single();

            var order = _mapper.Map<Order>(serviceModel);
            order.EmployeeId = employeeId;

            foreach (var product in serviceModel.Products)
            {
                order.ProductOrders.Add(new ProductOrder
                {
                    ProductId = product.ProductId,
                    Order = order
                });

            }

            //var payment = _mapper.Map<Payment>(serviceModel);
            //payment.PaymentStatus = PaymentStatus.Pending;
            //payment.Order = order;

            await _context.Orders.AddAsync(order);
            //await _context.Payments.AddAsync(payment);

            return await SaveChangesAsync(order) > 1;
        }
    }
}
