using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace GeekShopping.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Client = "Client";

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource> 
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScope => new List<ApiScope>//sao os dados dos clients
        {
            new ApiScope("geek_shopping", "Geek Shopping Serve"),
            new ApiScope(name:"read", "Read data."),
            new ApiScope(name:"write", "Write data."),
            new ApiScope(name:"delete", "Delete data."),
        };

        public static IEnumerable<Client> Clients => new List<Client>//ai é um client genérico
        {
            new Client
            {
                ClientId= "client",
                ClientSecrets =
                {
                    new Secret("my_super_secret".Sha256())//ai é uma scret encriptada em 256
                },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes =
                {
                    "read",
                    "write",
                    "profile"
                }
            },
            new Client
            {
                ClientId= "geek_shopping",
                ClientSecrets =
                {
                    new Secret("my_super_secret".Sha256())//ai é uma scret encriptada em 256
                },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = {"http://localhost:4431/sign-oidc"},
                PostLogoutRedirectUris = {"http://localhost:4431/signout-callback-oidc"},
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "geek_shopping"
                }
            }
        };
    }
}
