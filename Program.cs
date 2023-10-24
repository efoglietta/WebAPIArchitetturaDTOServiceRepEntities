using ArchitetturaDTOEntities.DataAccess;
using ArchitetturaDTOEntities.Repository;
using ArchitetturaDTOEntities.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy1",
        policy =>
        {
            policy.WithOrigins("http://example.com",
                                "http://localhost:54417");
        });

    options.AddPolicy("AnotherPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:54417")                                
                                .WithMethods("POST")
;
        });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connection string per Northwind context
builder.Services.AddDbContext<NorthwindContext>(options =>
{
    //modo 1
    string cnNorthwind = builder.Configuration.GetConnectionString("cnNW");
    //modo 2
    string cnNorthwind2 = builder.Configuration.GetValue<string>("ConnectionStrings:cnNW");

    options.UseSqlServer(cnNorthwind);

});



//CONTEXT
builder.Services.AddScoped<NorthwindContext, NorthwindContext>();

//REPOSITORY
builder.Services.AddScoped<IProdottiRepository, ProdottiRepository>();
//injection Generic Repository
builder.Services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

//SERVICES
builder.Services.AddScoped<IProdottiService, ProdottiService>();
builder.Services.AddScoped<IGenericProdottiService, GenericProdottiService>();
builder.Services.AddScoped<IProdottiServiceDTO, ProdottiServiceDTO>();

//AUTOMAPPER
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors();

app.UseCors("AnotherPolicy");


app.UseAuthorization();

app.MapControllers();

app.Run();
