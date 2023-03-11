using System.ComponentModel.DataAnnotations;
using DocumentFormat.OpenXml.Packaging;

namespace FileForm.Api.Validators;

public class DocxValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
	if (value is not IFormFile file) return new ValidationResult("");
        
        try
        {
            using var stream = file.OpenReadStream();
            using var package = WordprocessingDocument.Open(stream, false);
            if (package.DocumentType != DocumentFormat.OpenXml.WordprocessingDocumentType.Document)
            {
                return new ValidationResult("Invalid document format");
            }
        }
        catch (Exception)
        {
            return new ValidationResult("Invalid file format");
        }
        
        return ValidationResult.Success;
    }
}