using System.Text;
using Asp.Versioning;
using Manager.API.Middlewares;
using Manager.Application.Token;
using Manager.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<GlobalExceptionHandler>();

#region JwtAuthentication

builder.Services.Configure<TokenConfiguration>(builder.Configuration.GetSection("Jwt").Bind); 

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
#endregion

#region Swagger

builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Manager API",
        Description = "Uma API para gerenciar users"
    });

    options.AddSecurityDefinition(
        name: JwtBearerDefaults.AuthenticationScheme, 
        securityScheme: new()
        {
            Description = "Entre com um token para ter acesso: Bearer [Token]",
            Type = SecuritySchemeType.ApiKey,
            In = ParameterLocation.Header,
            Name = "X-API-Key"
        }
    );
});

#endregion

builder.Services.AddInfrastructure(builder.Configuration);

#region ApiVersioning
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

#endregion

builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<GlobalExceptionHandler>();

app.Run();

