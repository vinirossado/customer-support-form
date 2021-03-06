using CustomerSupport.Infra.CrossCutting.Enums;

namespace CustomerSupportAPI.ViewModels
{
    public class CustomerSupportViewModel
    {

        #region Properties
        public int Id { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public TypeInquiryEnum TypeInquiry { get; set; }
        public string Description { get; set; }
        public bool AgreementTerms { get; set; }

        #endregion Properties
    }
}
