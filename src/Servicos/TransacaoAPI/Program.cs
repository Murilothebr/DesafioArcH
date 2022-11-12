using TransacaoAPI.Data;
using TransacaoAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 void ServicesConfig(IServiceCollection service) { 

    service.AddScoped<ICatalogContext, CatalogContext>();
    service.AddScoped<ITransactRepository, TransactRepository>();
}
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Teste.API", Version = "v1.0.0" }); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
