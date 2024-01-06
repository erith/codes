```csharp
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace MyAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddServer(new OpenApiServer() { Url = "http://test.com" });

                options.SwaggerDoc("internal", new OpenApiInfo
                {
                    Title = "Simple API overview",
                    Version = "v1"
                });

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Public Facing API",
                    Version = "v1",

                });

                // 문서화 기능
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(c =>
                {
                    /*
                    c.PreSerializeFilters.Add((swagger, httpReq) =>
                    {
                        //                        if (swagger.Info.Title == "Internal API")
                        swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}" } };
                    });
                    */
                });
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/api-with-examples.json", "Simple API overview");
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Public Facing API");


                });
            }

            app.UseStaticFiles();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
```


cf.
https://tonylunt.medium.com/swashbuckle-cli-automating-asp-net-core-api-swagger-definitions-during-build-f3ee2b8e857a

```console
dotnet --list-sdks
dotnet new tool-manifest --sdk-version 6.0

# 6.5.0 은 sdk 7.0을 찾는 버그가 있다.
dotnet tool install Swashbuckle.AspNetCore.Cli --version 6.4.0

dotnet tool remove Swashbuckle.AspNetCore.Cli

dotnet tool run swagger tofile --output my-swagger.json bin\Debug\net6.0\MyAPI.dll v1
```
