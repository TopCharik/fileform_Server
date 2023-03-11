using FileForm.AzureBlob;
using FileForm.Core;

namespace FileForm.Api.Extensions;

public static class BlobServiceExtension
{
    public static void AddBlobService(this IServiceCollection services, string? connectionString, string? containerName)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Azure connection string is null or empty!");
        }

        if (string.IsNullOrEmpty(containerName))
        {
            throw new InvalidOperationException("Azure container string is null or empty!");
        }

        var blobConfiguration = new BlobServiceConfiguration
        {
            ConnectionString = connectionString,
            ContainerName = containerName,
        };

        services.AddSingleton<IFileSaveService>(x => new BlobService(blobConfiguration));

    }
}