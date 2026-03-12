using System.Security.Claims;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Http;
using BusinessObjects.Models.DTOs.Auth;
using BusinessObjects.Models.DTOs.Token;

namespace BusinessObjects.Interfaces.IServices;

public interface ITokenService
{
    string GenerateRefreshToken();
    string GenerateAccessToken(List<Claim> claims);
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    Task<GoogleJsonWebSignature.Payload?> VerifyGoogleToken(ExternalAuthDTO externalAuth);
    string GetTokenInsideCookie(string tokenKey, HttpContext context);
    void SetTokensInsideCookie(TokenDTO tokenDTO, HttpContext context);
}