using ConsultaTrabajadores.API.Data;
using ConsultaTrabajadores.API.Services.Implementations;
using ConsultaTrabajadores.API.Services.Interfaces;
using InformacionCiudades.API.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); //Esto hay que agregarlo para que no haga referencias circulares al serializar.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("ConsultaTrabajadoresApiBearerAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Acá pegar el token generado al loguearse."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ConsultaTrabajadoresApiBearerAuth" } //Tiene que coincidir con el id seteado arriba en la definición
                }, new List<string>() }
    });
});

builder.Services.AddDbContext<WorkersQuestionsContext>(dbContextOptions => dbContextOptions.UseSqlite(
    builder.Configuration["ConnectionStrings:ConsultaTrabajadoresDBConnectionString"]));

builder.Services.AddAuthentication("Bearer") //"Bearer" es el tipo de auntenticación que tenemos que elegir después en PostMan para pasarle el token
    .AddJwtBearer(options => //Acá definimos la configuración de la autenticación. le decimos qué cosas queremos comprobar. La fecha de expiración se valida por defecto.
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    }
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#region Repositories
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEmployerRepository, EmployerRepository>();
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
builder.Services.AddScoped<IResponseRepository, ResponseRepository>();
#endregion

#region Services
builder.Services.AddScoped<ICustomAuthenticationService, AutenticacionService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddScoped<IEmployerService, EmployerService>();
builder.Services.AddScoped<IResponseService, ResponseService>();
#endregion

builder.Services.AddHttpContextAccessor();

#if DEBUG
builder.Services.AddTransient<IMailService, LocalMailService>();
#else 
builder.Services.AddTransient<IMailService, CloudMailService>();
#endif

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // Agregar esto también

app.UseAuthorization();

app.MapControllers();

app.Run();
