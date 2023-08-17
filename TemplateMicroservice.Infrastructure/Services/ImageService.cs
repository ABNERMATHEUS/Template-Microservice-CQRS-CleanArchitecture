
using Azure.Storage.Blobs;
using System.Text.RegularExpressions;
using TemplateMicroservice.Domain.Services;

namespace TemplateMicroservice.Infrastructure.Services;

public class ImageService : IImageService
{
   
   

    public async Task<string> CreateImageAsync(string base64Image, string nameContainer, string keyContainer,  CancellationToken cancellationToken = default)
    {
        // Generate Random name file.
        var filename = Guid.NewGuid() + ".jpg";

        //Clean the hash base64 sending
        var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

        //Convert a Base64 to Array of Bytes
        var imageBytes = Convert.FromBase64String(data);

        // Define the blob in what the image to storage 
        var blobClient = new BlobClient(keyContainer, nameContainer, filename);

        //Envia a imagem
        await using (var stream = new MemoryStream(imageBytes))
        {
            await blobClient.UploadAsync(stream, cancellationToken);
        }

        return blobClient.Uri.AbsoluteUri;
    }

    public async Task DeleteImageAsync(string nameContainer, string keyContainer, string blobName, CancellationToken cancellationToken = default)
    {
        // Define the connection in what blob
        var blobClient = new BlobClient(keyContainer, nameContainer, blobName);

        //Delete if exist 
        await blobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken);
    }

    public async Task<bool> UpdateImageAsync(string nameContainer, string keyContainer, string base64Image, string blobNameActual, CancellationToken cancellationToken = default)
    {
        try
        {
            //Clean the hash base64 sending
            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

            //Convert a Base64 to Array of Bytes
            var imageBytes = Convert.FromBase64String(data);

            //Envia a imagem
            var blobName = "";
            foreach (var c in blobNameActual.Reverse().ToArray())
            {
                if (c == '/')
                    break;

                blobName += c;
            }

            blobName = new string(blobName.Reverse().ToArray());

            var blobClient = new BlobClient(keyContainer, nameContainer, blobName);
            var exist = await blobClient.ExistsAsync(cancellationToken);

            if (!exist) return false;

            await using var stream = new MemoryStream(imageBytes);

            await blobClient.UploadAsync(stream, overwrite: true, cancellationToken);

            return true;
        }
        catch
        {
            return false;
        }
    }
}
