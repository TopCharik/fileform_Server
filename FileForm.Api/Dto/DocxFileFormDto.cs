using System.ComponentModel.DataAnnotations;
using FileForm.Api.Validators;

namespace FileForm.Api.Dto;

public class DocxFileFormDto
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "File is required.")]
    [AllowedExtensions(new[] { ".docx" }, ErrorMessage = "Only {0} files are allowed!!!")]
    [DocxValidation]
    public IFormFile File { get; set; }
}