using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;
using TwitterBackEnd.Data;
using TwitterBackEnd.Data.Repositories;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
          .AddJsonOptions(options =>
          {
            var revolver = options.SerializerSettings.ContractResolver;
            if (revolver != null)
            {
              ((DefaultContractResolver)revolver).NamingStrategy = null;
            }
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          });

      services.AddMvc(options => options.EnableEndpointRouting = false);

      services.AddDbContext<ApplicationDbContext>(options =>
      {
        options.UseSqlServer(Configuration.GetConnectionString("DevConnection"));
      });

      services.AddDefaultIdentity<User>(options =>
      {

        options.Password.RequireDigit = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
      })
      .AddEntityFrameworkStores<ApplicationDbContext>();


      //services.AddCors(o => o.AddPolicy("LOL", builder => {}builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

      services.AddCors();
      services.AddSession();
      services.AddScoped<IUserRepository, GebruikerRepository>();

      var key = Encoding.UTF8.GetBytes(Configuration["JWT_SecretKey"]);

      services.AddAuthentication(s =>
      {
        s.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        s.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        s.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(jwt =>
      {
        jwt.RequireHttpsMetadata = false;
        jwt.SaveToken = false;
        jwt.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false,
          ClockSkew = TimeSpan.Zero
        };
      });

      #region NSwag
      services.AddOpenApiDocument(d =>
      {
        d.Description = "Back-end API written for Twipper";
        d.DocumentName = "Twipper";
        d.Version = "2.0.0";
        d.Title = "Twipper";
      });
      #endregion
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {

      var builder1 = new ConfigurationBuilder()
  .SetBasePath(env.ContentRootPath)
  .AddJsonFile("appsettings.json",
               optional: false,
               reloadOnChange: true)
  .AddEnvironmentVariables();

      if (env.IsDevelopment())
      {
        builder1.AddUserSecrets<Startup>();
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseCors(builder => builder.WithOrigins(Configuration["ApplicationSettings:Client_Url"])
      .AllowAnyHeader()
      .AllowAnyMethod());

      app.UseAuthentication();
      app.UseSession();
      app.UseHttpsRedirection();
      app.UseMvc();
      app.UseSwaggerUi3();
      app.UseSwagger();
    }
  }
}
