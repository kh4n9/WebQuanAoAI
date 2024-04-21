using System.ComponentModel.DataAnnotations;

namespace WebQuanAoAI.Repository.Validation
{
    public class FileExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);
                string[] extensions = { "jpeg", "jpg", "png" };

                bool result = extensions.Any(x => extension.EndsWith(x));

                if (!result)
                {
                    return new ValidationResult("Allowed extensions are jpg, jpeg, or png");
                }
            }
            return ValidationResult.Success;
        }

    }
}
