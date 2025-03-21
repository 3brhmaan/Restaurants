﻿using Microsoft.AspNetCore.Diagnostics;
using Restaurants.Domain.ErrorModel;
using Restaurants.Domain.Exceptions;

namespace Restaurants.API.Middlewares;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(opts =>
        {
            opts.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature != null)
                {

                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        BadRequestException => StatusCodes.Status400BadRequest,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    await context.Response.WriteAsync(
                        new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode ,
                            Message = contextFeature.Error.Message
                        }.ToString()
                    );
                }
            });
        });
    }
}
