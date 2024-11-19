using Duende.IdentityServer.Models;

namespace PortfolioWebsite.IdentityConfiguration
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource> { new IdentityResources.OpenId(), new IdentityResources.Profile() };

        public static IEnumerable<ApiScope> GetApiScopes() =>
            new List<ApiScope> { new ApiScope("portfolioApi", "Portfolio API") };

        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "portfolioClient",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    RedirectUris = { "https://localhost:5001/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:5001/signout-callback-oidc" },
                    AllowedScopes = { "openid", "profile", "portfolioApi" }
                }
            };
    }
}
