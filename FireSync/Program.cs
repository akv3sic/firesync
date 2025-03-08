using FireSync.Components;
using FireSync.Components.Account;
using FireSync.Data;
using FireSync.Data.Seeders;
using FireSync.MappingProfiles;
using FireSync.Models;
using FireSync.Repositories.Interfaces;
using FireSync.Repositories;
using FireSync.Services;
using FireSync.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FireSync.Settings;

namespace FireSync
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add custom configuration
            builder.Configuration.AddCustomConfiguration(builder.Environment);

            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(GeneralProfile));

            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

            var jwtSettings = builder.Configuration.GetSection("JWTSettings").Get<JWTSettings>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings!.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
                };
            })
            .AddIdentityCookies();

            // Add DB context
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityEmailSender>();

            // Services registration
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IStaffService, StaffService>();
            builder.Services.AddScoped<IInterventionService, InterventionService>();
            builder.Services.AddScoped<IInterventionTypeService, InterventionTypeService>();
            builder.Services.AddScoped<IVehicleService, VehicleService>();

            // Repositories registration
            builder.Services.AddScoped<IInterventionRepository, InterventionRepository>();
            builder.Services.AddScoped<IInterventionTypeRepository, InterventionTypeRepository>();
            builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            // Add MudBlazor
            builder.Services.AddMudServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Apply any pending migrations
                try
                {
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    // TODO: Log the exception
                }

                await IdentityDataSeeder.SeedRoles(roleManager);
                await IdentityDataSeeder.SeedDefaultAdmin(userManager);

                if (app.Environment.IsDevelopment())
                {
                    await TestDataSeeder.SeedData(dbContext, userManager);
                }
            }

            app.UseHttpsRedirection();
            app.UseStatusCodePages(context =>
            {
                var response = context.HttpContext.Response;

                if (response.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    response.Redirect("/404");
                }

                return Task.CompletedTask;
            });

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            // Add additional endpoints required by the Identity /Account Razor components.
            app.MapAdditionalIdentityEndpoints();

            app.Run();
        }
    }
}
