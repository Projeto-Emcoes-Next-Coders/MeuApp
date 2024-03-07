// cria instalção do contrutor
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// configurações do construtor 
builder.Services.AddControllers();
builder.Services.AddSwaggerGen( 
    c => {
        c.SwaggerDoc("v1", new OpenApiInfo{
            Title = "Empday",
            Version = "v1",
            Description = "App para registrar suas emoções",
            Contact = new OpenApiContact{
                Name = "Kauã Santos",
                Email = "kaua1457santos@gmail.com",  
            }
        });

        }
    );

// constroe a aplicação 
var app = builder.Build();

// define as rotas para os recursos da apricação
//app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json" , "Emoday");
});

// inicializa a aplicação
app.Run();
