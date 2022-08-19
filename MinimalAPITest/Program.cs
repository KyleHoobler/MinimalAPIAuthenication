using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MinimalAPIAuthentication.Repositories;
using MinimalAPIAuthentication.Services;
using MinimalAPITest.Services.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<IHashService, HashService>();
builder.Services.AddSingleton<ILoginRepository, LoginRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
    .RequireAuthenticatedUser().Build();
});

var app = builder.Build();

////TODO: Configure authorization...

app.UseFastEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3(s => s.ConfigureDefaults());

    app.UseDeveloperExceptionPage();
}



app.MapGet("Hello", [Authorize]() => "Hello World!");


app.Run();