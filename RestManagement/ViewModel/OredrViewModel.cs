using RestManagement.Service.ServiceModels;
using RestManagement.Shared.Enums;

namespace RestManagement.ViewModel
{
    public class OredrViewModel
    {
        public PaymentType paymentType { get; set; }
        public List<ProductSimpleViewModel> Products { get; set; }
    }
}
