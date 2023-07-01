using SurveyApp.Persistence;
using SurveyApp.Infrastructure;
using SurveyApp.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using SurveyApp.Persistence.EntityFramework.Seeding;
using SurveyApp.Persistence.EntityFramework.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(option => option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "SurveyApp API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token without Bearer keyword",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddAuthentication(options =>
                                  {
                                      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                                      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                                      options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                                  }).AddJwtBearer(options =>
                                  {
                                      options.TokenValidationParameters = new TokenValidationParameters
                                      {
                                          ValidateIssuer = false,
                                          ValidateAudience = false,
                                          ValidateLifetime = true,
                                          ValidateIssuerSigningKey = true,
                                          IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:Key").Value))
                                      };
                                  });

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<SurveyAppContext>();
context.Database.EnsureCreated();
EfDbSeeding.SeedDatabase(context);

app.Run();
