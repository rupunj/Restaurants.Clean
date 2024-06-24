using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.Extensions.Options;
using Restaurants.Clean.Domain;

namespace Restaurants.Clean.Infrastructure;

public class BlobStorageService(IOptions<BlobStorageSettings> blobStorageSettingsOoptions) : IBlobStorageService
{
    private readonly BlobStorageSettings _blobStorageSettings =  blobStorageSettingsOoptions.Value;
    public async Task<string> UploadLogo(Stream file, string Filename)
    {
        var blobServiceClient = new BlobServiceClient(_blobStorageSettings.ConnectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient(_blobStorageSettings.LogosContainerName);

        var blobClient = containerClient.GetBlobClient(Filename);

        await blobClient.UploadAsync(file);

        var filepath = blobClient.Uri.ToString();
        return filepath;

    }
    public string? GetBlobSasUrl(string? fileurl)
    {
        if (fileurl == null)
        {
            return null;
        }

        var sasBuilder = new BlobSasBuilder()
        {
            BlobContainerName = _blobStorageSettings.LogosContainerName,
            BlobName = Path.GetFileName(fileurl),
            Resource = "b",
            StartsOn = DateTime.UtcNow,
            ExpiresOn = DateTime.UtcNow.AddHours(1)
        };

        sasBuilder.SetPermissions(BlobSasPermissions.Read);
        var sasToken = sasBuilder
            .ToSasQueryParameters(new Azure.Storage.StorageSharedKeyCredential(_blobStorageSettings.AccountName,_blobStorageSettings.AccountKey))
            .ToString();

        return $"{fileurl}?{sasToken}";
    }
}
 