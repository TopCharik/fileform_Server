using FileForm.Api.Dto;
using FileForm.Core;

namespace FileForm.Api.Helpers;

public class FormMapper
{
    public FileRecord MapWordFormToFileRecord(DocxFileFormDto form)
    {
        var fileType = Path.GetExtension(form.File.FileName);
        var fileName = Guid.NewGuid() + fileType;
        var contentType = form.File.Headers.ContentType;

        var matadata = new Dictionary<string, string>();
        matadata.Add("originalFileName", form.File.FileName);
        matadata.Add("email", form.Email);


        return new FileRecord
        {
            Stream = form.File.OpenReadStream(),
            ContentType = contentType,
            Filename = fileName,
            Metadata = matadata,
        };
    }
}