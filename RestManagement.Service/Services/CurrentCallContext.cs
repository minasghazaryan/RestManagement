using Microsoft.AspNetCore.Http;
using RestManagement.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestManagement.Service.Services
{
    public class CurrentCallContext : ICurrentCallContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string UserId =>
            _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value??Guid.Empty.ToString();
        public DateTime UtcNow => DateTime.UtcNow;

        public CurrentCallContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
