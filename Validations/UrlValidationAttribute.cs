using System.ComponentModel.DataAnnotations;

namespace ClothingApi.Validations
{
    public class UrlValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            bool IsUrlValid = false;

            string Url = value.ToString();

            string http = Url.Substring(0, 12);
            if (http == "https://www.")
            {
                return new ValidationResult("Url must start with https://www.");   
            }
            return ValidationResult.Success;



        }
    }
}
