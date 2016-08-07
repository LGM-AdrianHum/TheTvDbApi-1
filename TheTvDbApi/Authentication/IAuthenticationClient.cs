using System.Security.Cryptography.X509Certificates;

namespace TheTvDbApi.Authentication {
    public interface IAuthenticationClient {
        string Token { get; }
        void RefreshToken();
    }
}