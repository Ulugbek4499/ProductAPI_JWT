using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Products_Application;
using Products_Infrastructure;
using Microsoft.OpenApi.Models;
using Serilog;



public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        Log.Logger = new LoggerConfiguration()
                   .Enrich.FromLogContext()
                   .ReadFrom.Configuration(builder.Configuration)
                   .CreateLogger();

        try
        {
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {{
                    new OpenApiSecurityScheme()
                    {
                       Reference=new OpenApiReference()
                       {
                           Id="Bearer",
                           Type=ReferenceType.SecurityScheme
                       }
                    },
                    new List<string>()
                } });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                string key = builder.Configuration.GetSection("Jwt").GetValue<string>("Key");
                byte[] convertKeyToBytes = Encoding.UTF8.GetBytes(key);

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(convertKeyToBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ValidateLifetime = true
                };
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
 
          
            app.MapControllers();

            app.Run();
        }
        catch(Exception ex)
        {
            Log.Fatal(ex, "Error");
        }
        finally
        {
            Log.CloseAndFlush();
        }
       
    }
}