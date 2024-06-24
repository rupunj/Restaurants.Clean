namespace Restaurants.Clean.Domain;

public interface IBlobStorageService
{
    Task<string> UploadLogo(Stream file, string Filename);
    string? GetBlobSasUrl(string? fileurl);

}
