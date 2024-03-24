using System.Text;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
                builder =>
                {
                    builder.WithOrigins("*")
                            .AllowAnyMethod().AllowAnyHeader();
                });
});

// Add services to Reverse Proxy.
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
// builder.Services.AddOcelot(builder.Configuration);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateLifetime = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = builder.Configuration["JWTKey:ValidAudience"],
                ValidIssuer = builder.Configuration["JWTKey:ValidIssuer"],
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTKey:Secret"]))
            };
        }
    );

builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(10);
        options.PermitLimit = 5;
    });
});

//builder.Services.AddMassTransit(x =>
//{
//    x.SetKebabCaseEndpointNameFormatter();
//    x.UsingRabbitMq((context, configurator) => {
//        configurator.Host(new Uri($"amqp://{builder.Configuration["RabbitMQ.Host"]}:{builder.Configuration["RabbitMQ.Port"]}"!), h =>
//        {
//            h.Username(builder.Configuration["RabbitMQ.Username"]);
//            h.Password(builder.Configuration["RabbitMQ.Password"]);
//        });
//        configurator.ConfigureEndpoints(context);
//    });
//});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "InfoPro Gateway", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Jwt Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InfoPro Gateway v1"));

app.UseRateLimiter();
app.UseStaticFiles();
app.UseCors("MyPolicy");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//app.MapControllers();
app.MapReverseProxy();

app.Run();
