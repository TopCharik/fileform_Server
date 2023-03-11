using FileForm.Api.Dto;
using FileForm.Api.Helpers;
using FileForm.Core;
using Microsoft.AspNetCore.Mvc;

namespace FileForm.Api.Controllers;

[ApiController]
public class FormController : ControllerBase
{
    private readonly IFileSaveService _fileSaveService;
    private readonly FormMapper _formMapper;
    private readonly ILogger<FormController> _logger;

    public FormController(IFileSaveService fileSaveService, FormMapper formMapper, ILogger<FormController> logger)
    {
        _fileSaveService = fileSaveService;
        _formMapper = formMapper;
        _logger = logger;
    }

    [HttpPost]
    [Route("docx")]
    public async Task<IActionResult> UploadFileRecord([FromForm]DocxFileFormDto form)
    {
        _logger.LogInformation($"File: {form.File.FileName} from Email: {form.Email} passed validation.");
        var fileRecord = _formMapper.MapWordFormToFileRecord(form);
        await _fileSaveService.SaveFileRecordAsync(fileRecord);   
        _logger.LogInformation($"File: {form.File.FileName} from Email: {form.Email} successfully uploaded");
        return Ok();
    }
}
