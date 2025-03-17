namespace Portfolio.Services.Services.UserJWT.Create;
public record TokenResponse
(
    string AccessToken,
    string RefreshToken,
    DateTime Expiration
    );