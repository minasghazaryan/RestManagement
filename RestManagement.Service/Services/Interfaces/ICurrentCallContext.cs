using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestManagement.Service.Services.Interfaces
{
    public interface ICurrentCallContext
    {
        string UserId { get; }
        DateTime UtcNow { get; }
    }
}
