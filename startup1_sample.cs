    public class Program
    {
        public static void Main(string[] args)
        {
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    if (string.IsNullOrEmpty(env))
                        env = "Production";
                    config.AddJsonFile("secretsettings.json", optional: false, reloadOnChange: false);
                    config.AddJsonFile($"secretsettings.{env}.json", optional: false);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
    
   ---
   public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DbHelperBase.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {



            //Cors 설정
            services.AddCors(options=>
            {
                options.AddPolicy("AllowAll",
                          builder =>
                          {
                              builder
                              .AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                          });
            });

            //컨트롤러 설정
            services.AddControllers()                
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver() { NamingStrategy = null };
                        options.SerializerSettings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        options.SerializerSettings.DateParseHandling = DateParseHandling.None;
                        options.SerializerSettings.Converters.Add(new IsoDateTimeConverter { 
                            DateTimeStyles = DateTimeStyles.AssumeLocal
                            //,DateTimeFormat = "yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz"
                            //,DateTimeFormat = "yyyy-MM-ddTHH\\:mm\\:sszzz"
                        });
                    })
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                        options.JsonSerializerOptions.PropertyNamingPolicy = null;

                    }); //이 처리를 해줘야 JSON 포맷 네이밍을 자동 변환하지 않는다.;

            //## NSwag 설정
            services.AddOpenApiDocument(document =>
            {
                document.Title = "JS OFFICE APP";
                document.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    
                });
                document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
                document.SerializerSettings = new JsonSerializerSettings()
                {
                    //네이밍 컨벤션 처리가 안되서 직접  NSwager 소스를 수정함.
                    //ContractResolver = new CamelCasePropertyNamesContractResolver()
                    ContractResolver = null                    
                };
            });

            //JWT 설정
            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // 유저정보 서비스 등록
            services.AddScoped<IUserService, UserService>();

            // HttpService
            services.AddHttpClient<MailService>();

            // 접근 정보 등록
            services.AddAuthorization(config =>
            {
                config.AddPolicy("ADMIN", new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole("ADMIN").Build());
                config.AddPolicy("STAFF", new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole("STAFF").Build());
            });

            // 프론트 엔드 서비스 경로(리액트 빌드 파일들)
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });


            // TimeHosted 서비스
            services.AddSingleton<TimeHostedService>();
            //services.AddHostedService<TimeHostedService>();
            services.AddHostedService(sp => sp.GetRequiredService<TimeHostedService>());
            //SignalR 서비스
            services.AddSignalR();

            services.AddControllersWithViews();
        }

        /// <summary>
        /// 애플리케이션 루트 디렉토리를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public string GetApplicationRoot()
        {
            var exePath = Path.GetDirectoryName(System.Reflection
                              .Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return appRoot;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(options => {
                    options.Run(async context => {

                        var ex = context.Features.Get<IExceptionHandlerFeature>();
                        if (ex != null)
                        {
                            var seq = UserDbHelper.DbLog("ERROR", context.Request.Path + context.Request.QueryString??"" + "::" + ex.Error.Message + "/" + ex.Error.StackTrace);
                        }
                        await Task.CompletedTask;
                    });
                });
            }

            Uploader.WebRootPath = env.ContentRootPath;

            
            app.UseCors(x => x
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .SetIsOriginAllowed(origin => true) // allow any origin
                      .AllowCredentials()); // allow credentials

            //app.UseHttpsRedirection();

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Static")),
                RequestPath = new PathString("/static"),
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 60 * 24;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                        "public,max-age=" + durationInSeconds;
                }
            });

            app.UseSpaStaticFiles();

            app.UseRouting();


            // swagger restrict
            app.UseMiddleware<SwaggerBasicAuthMiddleware>();


            //## NSwag
            app.UseOpenApi();
            app.UseSwaggerUi3();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "home",
                    pattern: "home/{action=Index}/{seq?}",
                    defaults: new { controller = "Home", action = "Index"}
                    );
                endpoints.MapHub<ChatHub>("/hub");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
            });
        }
    }
   
