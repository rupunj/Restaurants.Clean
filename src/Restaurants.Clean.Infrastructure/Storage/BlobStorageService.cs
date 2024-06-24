using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using Restaurants.Clean.Domain;

namespace Restaurants.Clean.Infrastructure;

public class BlobStorageService(IOptions<BlobStorageSettings> blobStorageSettingsOoptions) : IBlobStorageService
{
    private readonly BlobStorageSettings _blobStorageSettings =  blobStorageSettingsOoptions.Value;
    public async Task<string> UploadLogo(Stream file, string Filename)
    {
        try
        {
            
            var blobServiceClient = new BlobServiceClient(_blobStorageSettings.ConnectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(_blobStorageSettings.LogosContainerName);

            var blobClient = containerClient.GetBlobClient(Filename);

            await blobClient.UploadAsync(file);

            var filepath = blobClient.Uri.ToString();
            return filepath;
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }
}
 