# Getting started
- This project developed with `.NET CORE Web API` by `Mehmet Ali Külle`.
- Aim of project is getting understand how we can do global error exception and how can we write filter for API methods.

# Code Overview

- `Backend/Core` . This project includes repositories, database tables (entities), Services and Unitofwork pattern
- `Backend/Data` . This projec includes data access layer.
- `Backend/Service` . This project includes service layer for API project.
- `Backend/API`. API project of solution. This project includes controller , Automapper, Models.
 * `Backend/API/Error` . Global Error Dto Class.
 * `Backend/API/Filters` . This folder includes filter such as `NotFoundFilter`, `ValidationFilters`.  Usage of this ;
    - `[NotFoundFilter]` , `[ValidationFilters]` on controllers.
 * `Backend/API/Extensions` , This folder includes custom exception Handler.
 
 
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();

                    if (error != null)
                    {
                        var ex = error.Error;
                        ErrorDto errorDto = new ErrorDto();
                        errorDto.Status = 500;
                        errorDto.Errors.Add(ex.Message);

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                    }
                });
            });

            return app;
        }
