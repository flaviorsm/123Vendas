using _123Vendas.Aplicacao.Interfaces;
using _123Vendas.Aplicacao.Mapeamentos;
using _123Vendas.Aplicacao.Servicos;
using _123Vendas.Infraestrutura.Data;
using _123Vendas.Infraestrutura.Eventos;
using Eventos;
using Persistencia;
using Repositorios;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IVendaRepositorio, VendaRepositorio>();
builder.Services.AddScoped<IVendaServico, VendaServico>();
builder.Services.AddScoped<IPublicarEvento, PublicarEvento>();

builder.Services.AddAutoMapper(typeof(MapeamentoProfile));

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/Error");
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
