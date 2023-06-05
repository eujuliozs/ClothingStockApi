using System.ComponentModel.DataAnnotations;

namespace ClothingApi.Validations
{
    public class SizeValidationAttribute : ValidationAttribute
    {
        public SizeValidationAttribute()
        {
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            bool IsValidSize = false;

            string[] sizes = {"PP", "P", "M", "G", "GG", "GGG"};

            foreach (string size in sizes) 
            {
                if(value.ToString().ToUpper() == size) { IsValidSize = true; break; }
            }

            if (IsValidSize) { return ValidationResult.Success; }

            return new ValidationResult(ErrorMessage=$"Invalid {validationContext.MemberName}, size must be [PP, P, M, G, GG, GGG]");
        }
    }
}
