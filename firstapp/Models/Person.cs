using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MyFirstApp.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace MyFirstApp.Models
{
    public class Person : IValidatableObject
    {

        [Required(ErrorMessage ="Please enter {0}")]
        [Display(Name ="Person Name")]
        [StringLength(10,MinimumLength =5,ErrorMessage ="{0} characters Length between {2} to {1}")]
        public string? PersonName { get; set; }

        public int? Age { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }
        [ValidateNever]
        [EmailAddress(ErrorMessage ="Please enter valid {0}")]
        public string? EmailId { get; set;}

        [Phone(ErrorMessage = "Please enter valid {0}")]
        public string? PhoneNumber { get; set;}

        //[MinimumYearValidatorAttribute(2005, ErrorMessage = "Minimum Year required is above {0}")]
        public DateTime DateOfBirth { get; set; }

        [RegularExpression("^[0-9]{6}$",ErrorMessage ="Please enter valid {0}")]
        //[Range(100001,699999,ErrorMessage ="{0} range between {1} to {2}")]
        public Double? PostalCode { get; set;}


        public DateTime? FromDate { get; set; }

        [DateRangeValidatorAttribute("FromDate",ErrorMessage="'FromDate' Should be older than or equel to 'ToDate'")]
        public DateTime? ToDate { get; set; }

        
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage="{0} cant match the {1}")]
        public string? ConfPassword { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(String.IsNullOrWhiteSpace(DateOfBirth.ToString()) && Age.HasValue == false)
            {
                yield return new ValidationResult("Please enter either Dateofbirth or Age", new[] {nameof(Age)});
            }
        }
    }
}
