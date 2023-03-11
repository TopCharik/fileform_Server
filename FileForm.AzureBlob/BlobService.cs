using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FileForm.Core;

namespace FileForm.AzureBlob;

public class BlobService : IFileSaveService
{
    private readonly BlobContainerClient _containerClient;

    public BlobService(BlobServiceConfiguration configuration)
    {
        _containerClient = new BlobContainerClient(configuration.ConnectionString, configuration.ContainerName);
    }

    public async Task SaveFileRecordAsync(FileRecord fileRecord)
    {
        var blobClient = _containerClient.GetBlobClient(fileRecord.Filename);
        
        var options = new BlobUploadOptions();
        options.Metadata = fileRecord.Metadata;

        var headers = new BlobHttpHeaders();
        headers.ContentType = fileRecord.ContentType;
        options.HttpHeaders = headers;

        await blobClient.UploadAsync(fileRecord.Stream ,options );
    }
}