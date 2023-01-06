namespace TemplateMicroservice.Core.Services;

public interface ITokenService
{
    string GenerateAccessTokenAsync(Guid id, string username);
}