﻿using SampleProject.API.BaseMiddlewares;

namespace SampleProject.API;

public static class BaseAppUseExtensions
{
    public static IApplicationBuilder BaseAppUse(this IApplicationBuilder app)
    {
        app
            .UsingMiddlewares()
            .UsingCors()
            .UsingSwagger()
            .UsingAuthorization();

        return app;
    }

    public static IApplicationBuilder UsingMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<UnauthorizedMiddleware>();
        app.UseMiddleware<ForbiddenMiddleware>();
        app.UseMiddleware<InternalServerErrorMiddleware>();

        return app;
    }

    public static IApplicationBuilder UsingCors(this IApplicationBuilder app)
    {
        app.UseCors("allowall");

        return app;
    }

    public static IApplicationBuilder UsingSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    public static IApplicationBuilder UsingAuthorization(this IApplicationBuilder app)
    {
        app.UseAuthorization();

        return app;
    }
}