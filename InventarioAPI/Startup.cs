﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InventarioAPI.Contexts;
using InventarioAPI.Entities;
using InventarioAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InventarioAPI
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
            services.AddAutoMapper(options =>
            {
                options.CreateMap<CategoriaCreacionDTO, Categoria>();
                options.CreateMap<TipoEmpaqueCreacionDTO, TipoEmpaque>();
                options.CreateMap<ClienteCreacionDTO, Cliente>();
                options.CreateMap<ProveedorCreacionDTO, Proveedor>();
                options.CreateMap<ProductoCreacionDTO, Producto>();
                options.CreateMap<FacturaCreacionDTO, Factura>();
                options.CreateMap<DetalleFacturaCreacionDTO, DetalleFactura>();
                options.CreateMap<CompraCreacionDTO, Compra>();
                options.CreateMap<DetalleCompraCreacionDTO, DetalleCompra>();
                options.CreateMap<EmailClienteCreacionDTO, Emailcliente>();
                options.CreateMap<EmailProveedorCreacionDTO, EmailProveedor>();
                options.CreateMap<InventarioCreacionDTO, Inventario>();
                options.CreateMap<TelefonoClienteCreacionDTO, TelefonoCliente>();
                options.CreateMap<TelefonoProveedorCreacionDTO, TelefonoProveedor>();
            });
            services.AddDbContext<InventarioDBContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            services.AddDbContext<InventarioIdentityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("authConnection")));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:key"]))
            }) ;
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
