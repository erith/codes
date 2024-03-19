using Microsoft.OpenApi.Models;

public class SwaggerConfigurator
{
    public static OpenApiDocument ConfigureSwagger()
    {
        var swaggerDoc = new OpenApiDocument
        {
            Info = new OpenApiInfo
            {
                Version = "v1",
                Title = "Your API",
                Description = "Description of your API",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Your Name",
                    Email = "your.email@example.com",
                    Url = new Uri("https://example.com/contact"),
                },
                License = new OpenApiLicense
                {
                    Name = "License Name",
                    Url = new Uri("https://example.com/license"),
                }
            },
            Servers = new List<OpenApiServer>
            {
                new OpenApiServer { Url = "https://api.example.com" }
            },
            Paths = new OpenApiPaths
            {
                // Define your API paths here
                ["/api/endpoint"] = new OpenApiPathItem
                {
                    Operations = new Dictionary<OperationType, OpenApiOperation>
                    {
                        [OperationType.Get] = new OpenApiOperation
                        {
                            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Endpoint Tag" } },
                            Summary = "Summary of the GET operation",
                            Description = "Description of the GET operation",
                            Responses = new OpenApiResponses
                            {
                                ["200"] = new OpenApiResponse
                                {
                                    Description = "OK"
                                }
                            }
                        }
                    }
                }
            },
            Components = new OpenApiComponents
            {
                // Define your API components (schemas, security schemes, etc.) here
            }
        };

        return swaggerDoc;
    }
}
