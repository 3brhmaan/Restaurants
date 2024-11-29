﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Restaurants.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection service)
    {
        service.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
        service.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly)
            .AddFluentValidationAutoValidation();
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
    }
}
