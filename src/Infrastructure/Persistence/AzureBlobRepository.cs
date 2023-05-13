using OI.Template.Domain.Repository;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using OI.Template.Infrastructure.Configuration;

namespace OI.Template.Infrastructure.Persistence;

public class AzureBlobRepository : IBlobStorageRepository
{
    private readonly BlobServiceClient _blobClient;
    private readonly string _containerName;

    public AzureBlobRepository(IOptions<AzureConfiguration> configuration)
    {
        _blobClient = new BlobServiceClient(configuration.Value.ConnectionString);
        _containerName = configuration.Value.ContainerName;
    }

    public async Task<string> UploadFile(Stream fileStream, string fileName)
    {
        var containerClient = _blobClient.GetBlobContainerClient(_containerName);
        await containerClient.CreateIfNotExistsAsync();

        var blobClient = containerClient.GetBlobClient(fileName);
        await blobClient.UploadAsync(fileStream);

        return blobClient.Uri.AbsoluteUri;
    }
}