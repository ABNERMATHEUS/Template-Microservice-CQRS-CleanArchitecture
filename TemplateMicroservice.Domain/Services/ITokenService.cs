namespace TemplateMicroservice.Domain.Services;

public interface ITokenService
{
    string GenerateAccessTokenAsync(Guid id, string username);
}