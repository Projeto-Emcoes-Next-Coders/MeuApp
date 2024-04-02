using System.Text;
using Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<DbEmoday>(config => config.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Api RESTEfull EmoDay",
            Version = "v1",
            Description = "Api RESTEfull para funcionalidades da aplicação.",
            Contact = new OpenApiContact
            {
                Name = "Edney Coutinho",
                Email = "junior_cle@hotmail.com"
            }
        });
        //c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "MeuApp.xml"));
    }
);
builder.Services
    .AddAuthentication(c => {
        c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        c.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(c => {
        c.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Emodayy")),
            ValidateAudience = false,
            ValidateIssuer = false
        };
    });

var app = builder.Build();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json" , "Emoday");
});
app.UseAuthentication();
app.UseAuthorization();

app.Run();
