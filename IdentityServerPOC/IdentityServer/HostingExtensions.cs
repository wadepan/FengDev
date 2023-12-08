using Duende.IdentityServer;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using IdentityServerHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace IdentityServer;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
        //set up sql for configuration
        
        const string connectionString = @"Data source=192.168.100.89;initial catalog=IdentityServerConfig;User ID=eFilingAppUser; Password=@dm1nP@ssSQL; MultipleActiveResultSets=true;MultiSubnetFailover=False;Encrypt=False";
        const string connectionStringPersist = @"Data source=192.168.100.89;initial catalog=IdentityServerPersist;User ID=eFilingAppUser; Password=@dm1nP@ssSQL; MultipleActiveResultSets=true;MultiSubnetFailover=False;Encrypt=False";
        builder.Services
             .AddIdentityServer(options =>
             {
                 options.Events.RaiseErrorEvents = true;
                 options.Events.RaiseInformationEvents = true;
                 options.Events.RaiseFailureEvents = true;
                 options.Events.RaiseSuccessEvents = true;
                 options.EmitStaticAudienceClaim = true;
             })
             .AddConfigurationStore(options =>
             {
                 options.ConfigureDbContext = b => b.UseSqlServer(connectionString);
             })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(connectionStringPersist);
                options.EnableTokenCleanup = true;
                options.RemoveConsumedTokens = true;
            })
            .AddTestUsers(TestUsers.Users);

        builder.Services.AddAuthentication()
            .AddOpenIdConnect("oidc", "Demo IdentityServer", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                options.SignOutScheme = IdentityServerConstants.SignoutScheme;
                options.SaveTokens = true;

                options.Authority = "https://demo.duendesoftware.com";
                options.ClientId = "interactive.confidential";
                options.ClientSecret = "secret";
                options.ResponseType = "code";

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = "role"
                };
            });

        return builder.Build();
    }
   
    public static WebApplication ConfigurePipeline(this WebApplication app)
    { 
        app.UseSerilogRequestLogging();
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
       
        app.UseStaticFiles();
        app.UseRouting();
            
        app.UseIdentityServer();

        app.UseAuthorization();
        app.MapRazorPages().RequireAuthorization();

        return app;
    }
}