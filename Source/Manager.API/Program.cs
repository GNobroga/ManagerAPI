using System.Text;
using Asp.Versioning;
using Manager.API.Middlewares;
using Manager.API.Token;
using Manager.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<GlobalExceptionHandler>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        var tokenConfiguration = new TokenConfiguration("", "", 1);

        builder.Configuration.GetSection("Jwt").Bind(tokenConfiguration);

        options.TokenValidationParameters = new()
        {   
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidIssuer = tokenConfiguration.Issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Secret))
        };
    });

builder.Services.AddInfrastructure(builder.Configuration);

var apiVersioningBuilder = builder.Services.AddApiVersioning(options => {
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver")
    );
});

apiVersioningBuilder.AddApiExplorer(options => {
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddApplicationServices();

builder.Services.Configure<TokenConfiguration>(builder.Configuration.GetSection("Jwt").Bind); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();
app.UseMiddleware<GlobalExceptionHandler>();

app.Run();

