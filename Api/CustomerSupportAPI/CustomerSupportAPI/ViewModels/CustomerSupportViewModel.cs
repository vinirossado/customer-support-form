namespace CustomerSupportAPI.ViewModels
{
    public class CustomerSupportViewModel
    {

        #region Properties
        public int Id { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public int TypeInquiry { get; set; }
        public string Description { get; set; }
        public bool AgreementTerms { get; set; }

        #endregion Properties
    }
}
