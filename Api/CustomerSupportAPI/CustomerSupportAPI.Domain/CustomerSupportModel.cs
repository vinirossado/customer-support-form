namespace CustomerSupportAPI.Domain
{
    public class CustomerSupportModel
    {

        #region Properties
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string? Number { get; private set; }
        public int TypeInquiry { get; private set; }
        public string Description { get; private set; }
        public bool AgreementTerms { get; private set; }

        #endregion Properties

        #region Constructors
        public CustomerSupportModel() { }
        public CustomerSupportModel(string email, string phone, string? number, int typeInquiry, string description, bool agreementTerms)
        {
            Email = email;
            Phone = phone;
            Number = number;
            TypeInquiry = typeInquiry;
            Description = description;
            AgreementTerms = agreementTerms;
        }
        public CustomerSupportModel(int id, string email, string phone, string? number, int typeInquiry, string description, bool agreementTerms)
        {
            Id = id;
            Email = email;
            Phone = phone;
            Number = number;
            TypeInquiry = typeInquiry;
            Description = description;
            AgreementTerms = agreementTerms;
        }

        #endregion Constructors

        #region Methods
        public void UpdateEntity(int id, string email, string phone, string? number, int typeInquiry, string description, bool agreementTerms)
        {
            Id = id;
            Email = email;
            Phone = phone;
            Number = number;
            TypeInquiry = typeInquiry;
            Description = description;
            AgreementTerms = agreementTerms;
        }
        #endregion Methods
    }
}