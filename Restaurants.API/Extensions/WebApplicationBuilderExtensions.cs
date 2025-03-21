﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Restaurants.API.ActionFilters;
using Restaurants.API.Middlewares;
using Serilog;

namespace Restaurants.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("bearerAuth" , new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http ,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference{Type = ReferenceType.SecurityScheme , Id = "bearerAuth"}
                    } ,
                    []
                }
            });
        });

        builder.Services.AddScoped<RequestTimeLoggingMiddleware>();

        builder.Host.UseSerilog((ctx , cfg) =>
        {
            cfg.ReadFrom.Configuration(ctx.Configuration);
        });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });
        builder.Services.AddScoped<ValidationFilterAttribute>();
    }
}
