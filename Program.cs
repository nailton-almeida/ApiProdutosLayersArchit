using ApiCatalogoProdutos.Model;
using ApiCatalogoProdutos.Repositories;
using AutoMapper;
using CatalogoProdutosMinimalAPI.DTO.Mappings;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProdutoRepository,   ProdutoRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

var mappingConfig = new MapperConfiguration(mc =>
{

    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

string? mysqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers().AddJsonOptions(options => 
{ 
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles; 
});

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(mysqlConnection, ServerVersion.AutoDetect(mysqlConnection)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
