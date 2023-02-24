using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TodoApp.Core.Src.Handlers;
using TodoApp.Core.Src.Repositories;
using TodoApp.Core.Src.Services;
using TodoApp.Infra.Src.Configs;
using TodoApp.Infra.Src.Configs.Contracts;
using TodoApp.Infra.Src.DataContext;
using TodoApp.Infra.Src.Repositories;
using TodoApp.Infra.Src.Services;
using TodoApp.Share;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IDataBaseBootstrap, SqliteBootstrap>();

builder.Services.AddScoped<TodoAppContext, TodoAppContext>();

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<CustomerHandler, CustomerHandler>();

builder.Services.AddTransient<ITodoListRepository, TodoListRepository>();
builder.Services.AddTransient<TodoListHandler, TodoListHandler>();

builder.Services.AddTransient<ITodoItemRepository, TodoItemRepository>();
builder.Services.AddTransient<TodoItemHandler, TodoItemHandler>();

builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<ISmsService, SmsService>();
builder.Services.AddTransient<IEmailService, EmailService>();


builder.Services.AddAuthorization();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;

        var key = Encoding.ASCII.GetBytes(Settings.SecretToken);
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddControllers();
builder.Services.AddResponseCompression();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "UP");

app.Services.GetService<IDataBaseBootstrap>().InitialSetup();

app.Run();