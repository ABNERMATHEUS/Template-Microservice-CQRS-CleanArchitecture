namespace TemplateMicroservice.Domain.Services;

public interface IImageService
{

    Task<string> CreateImageAsync(string base64Image, string nameContainer, string keyContainer, CancellationToken cancellationToken = default);

    Task DeleteImageAsync(string nameContainer, string keyContainer, string blobName, CancellationToken cancellationToken = default);

    Task<bool> UpdateImageAsync(string nameContainer, string keyContainer, string base64Image, string blobNameActual, CancellationToken cancellationToken = default);
}
