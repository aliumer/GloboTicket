using Duende.IdentityServer.Models;

namespace Globoticket.Services.Identity;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource("globoticketapi", "GloboTicket APIs")
            {
                Scopes = { "globoticket.fullaccess" }
            },
        };
    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[] 
        {
            new ApiScope("globoticket.fullaccess"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[] 
        {
            new Client
            {
                ClientName = "Globoticket Mchine 2 Machine Client",
                ClientId = "globoticketm2m",
                ClientSecrets = { new Secret("SuperSecretPassword".Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "globoticket.fullaccess" },
            }
        };
}
