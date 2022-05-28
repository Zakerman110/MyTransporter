using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    public static class Configuration
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client {
                    ClientId = "angular",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris = { "http://localhost:4200" },
                    PostLogoutRedirectUris = { "http://localhost:4200" },
                    AllowedCorsOrigins = { "http://localhost:4200" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        "OrderAPI",
                        "TransportAPI",
                        "FeedbackAPI",
                        "roles"
                    },

                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                }
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                //new ApiResource("OrderAPI", "Order API"),
                //new ApiResource("TransportAPI", "Transport API"),
                //new ApiResource("FeedbackAPI", "Feedback API"),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("OrderAPI", "Order API"),
                new ApiScope("TransportAPI", "Transport API"),
                new ApiScope("FeedbackAPI", "Feedback API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", new[] { "role" }),
                new IdentityResources.Address(),
                new IdentityResources.Email()
            };
    }
}
