using RestManagement.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestManagement.Service.ServiceModels
{
    public class OredrServiceModel
    {
        public PaymentType paymentType { get; set; }
        public List<ProductSimpleServiceModel> Products { get; set; }
    }
}
