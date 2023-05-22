using System.ComponentModel.DataAnnotations;
using System.Reflection;
namespace MyFirstApp.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string OtherPropertyName { get; set; }


        public DateRangeValidatorAttribute(string otherpropertyname) 
        {
            OtherPropertyName = otherpropertyname;

        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                //get todate
                DateTime to_date = Convert.ToDateTime(value);

                //get from date
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

                if(otherProperty != null)
                {
                    DateTime from_date = Convert.ToDateTime(otherProperty?.GetValue(validationContext.ObjectInstance)); ;

                    if (from_date > to_date)
                    {
                        return new ValidationResult(ErrorMessage, new string[] { validationContext.MemberName! });
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }

                }
               
            }
            return null;
        }
    }
}
