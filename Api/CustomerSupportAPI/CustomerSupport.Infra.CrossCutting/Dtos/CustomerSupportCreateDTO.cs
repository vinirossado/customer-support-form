using CustomerSupport.Infra.CrossCutting.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CustomerSupport.Infra.CrossCutting.Dtos
{
    public class CustomerSupportCreateDTO
    {
        #region Properties

        [Required(ErrorMessage = "Email is mandatory")]
        [EmailAddress(ErrorMessage = "Enter valid Email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is mandatory")]
        public string Phone { get; set; }

        public string? Number { get; set; }

        [Required(ErrorMessage = "Type of Inquiry is mandatory")]
        [Range(minimum: 0, maximum: 2, ErrorMessage = "Enum is out of range")]
        public TypeInquiryEnum TypeInquiry { get; set; }

        [Required(ErrorMessage = "Description is mandatory")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You need to agree with terms")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You need to agree with terms")]
        public bool AgreementTerms { get; set; }

        #endregion Properties
    }
}
