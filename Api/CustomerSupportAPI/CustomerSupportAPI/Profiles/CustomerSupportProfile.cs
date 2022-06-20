using AutoMapper;
using CustomerSupportAPI.Domain;
using CustomerSupportAPI.ViewModels;

namespace CustomerSupportAPI.Profiles
{
    public class CustomerSupportProfile : Profile
    {
        public CustomerSupportProfile()
        {
            CreateMap<CustomerSupportModel, CustomerSupportViewModel>();
        }
    }
}
