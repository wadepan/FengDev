// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using Duende.IdentityServer;
using Duende.IdentityServer.Test;
using IdentityModel;
using System.Security.Claims;
using System.Text.Json;

namespace SCUSIdentityServerSQL
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "One Hacker Way",
                    locality = "Heidelberg",
                    postal_code = 69118,
                    country = "Germany"
                };

                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "1",
                        Username = "admin",
                        Password = "Password1!",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Admin"),
                            new Claim(JwtClaimTypes.GivenName, "Admin"),
                            new Claim(JwtClaimTypes.FamilyName, "Admin"),
                            new Claim(JwtClaimTypes.Email, "efilingitsupport@scinet.gov"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            //new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                            //new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    }
                };
            }
        }
    }
}