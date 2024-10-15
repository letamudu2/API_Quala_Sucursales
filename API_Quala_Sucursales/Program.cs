using API_Quala_Sucursales_Datos;
using API_Quala_Sucursales_Negocio;
using API_Quala_Sucursales_Negocio.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin() // Permite cualquier origen
                          .AllowAnyMethod() // Permite cualquier método (GET, POST, etc.)
                          .AllowAnyHeader()); // Permite cualquier cabecera
});

builder.Services.AddTransient<ISucursales, API_Quala_Sucursales_Negocio.Sucursales>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
