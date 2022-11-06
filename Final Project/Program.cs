using Business.Abstract;
using Business.Concrete;
using Core.Entity.Models;
using Core.Security.Hashing;
using Core.Security.Models;
using Core.Security.TokenHandler;
using DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<JWTConfig>(builder.Configuration.GetSection("JWTConfig"));


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    var key = Encoding.ASCII.GetBytes("aqwertyuiopsadfghjklxcvbnmasdfghjkwertyukj");
    var issuer = builder.Configuration["JWTConfig:Issuer"];
    var audience = builder.Configuration["JWTConfig:Audience"];
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
        ValidIssuer = issuer,
        ValidAudience = audience
    };
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IBlogCategoryDal, BlogCategoryDal>();
builder.Services.AddScoped<IBlogCategoryManager, BlogCategoryManager>();

builder.Services.AddScoped<IBlogDal, BlogDal>();
builder.Services.AddScoped<IBlogManager, BlogManager>();

builder.Services.AddScoped<IBrandDal, BrandDal>();
builder.Services.AddScoped<IBrandManager, BrandManager>();

builder.Services.AddScoped<ICarDal, CarDal>();
builder.Services.AddScoped<ICarManager, CarManager>();

builder.Services.AddScoped<ICarImageDal, CarImageDal>();
builder.Services.AddScoped<ICarImageManager, CarImageManager>();

builder.Services.AddScoped<IDealerDal, DealerDal>();
builder.Services.AddScoped<IDealerManager, DealerManager>();

builder.Services.AddScoped<IFeatureDal, FeatureDal>();
builder.Services.AddScoped<IFeatureManager, FeatureManager>();

builder.Services.AddScoped<IModelDal, ModelDal>();
builder.Services.AddScoped<IModelManager, ModelManager>();

builder.Services.AddScoped<IServiceDal, ServiceDal>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

builder.Services.AddScoped<ISocialDal, SocialDal>();
builder.Services.AddScoped<ISocialManager, SocialManager>();

builder.Services.AddScoped < IAuthDal, AuthDal>();
builder.Services.AddScoped<IAuthManager, AuthManager>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<HashingHandler>();


builder.Services.AddScoped<TokenGenerator>();
builder.Services.AddScoped<JWTConfig>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        policy =>
        {
            policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);
  
app.UseAuthentication();


app.UseAuthorization();

app.MapControllers();

app.Run();
