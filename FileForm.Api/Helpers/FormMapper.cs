using System.Globalization;
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

        var indMapper = new IdnMapping();
        var asciiFileName = indMapper.GetAscii(form.File.FileName);
        var asciiEmail = indMapper.GetAscii(form.Email);

        var matadata = new Dictionary<string, string>();
        matadata.Add("originalFileName", asciiFileName);
        matadata.Add("email", asciiEmail);


        return new FileRecord
        {
            Stream = form.File.OpenReadStream(),
            ContentType = contentType,
            Filename = fileName,
            Metadata = matadata,
        };
    }
}