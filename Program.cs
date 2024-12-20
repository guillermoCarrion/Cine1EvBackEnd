using CineAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);


// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirOrigenLocal", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500", "http://34.225.199.154:5500") // Permitir el acceso desde tu frontend
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
// Configuración de CORS en el pipeline de la aplicación
app.UseCors("PermitirOrigenLocal");


// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
PeliculaController.InicializarDatos();
app.Run("http://0.0.0.0:7141");

//http://localhost:5165/swagger/index.html