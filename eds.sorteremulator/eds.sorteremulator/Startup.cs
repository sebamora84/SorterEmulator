using Autofac;
using eds.sorteremulator.communiation;
using eds.sorteremulator.communiation.Sockets;
using eds.sorteremulator.configuration;
using eds.sorteremulator.fileservices;
using eds.sorteremulator.services.Hubs;
using eds.sorteremulator.services.NodeActions;
using eds.sorteremulator.services.NodeActions.Base;
using eds.sorteremulator.services.Processors;
using eds.sorteremulator.services.Processors.Base;
using eds.sorteremulator.services.Services;
using eds.sorteremulator.services.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace eds.sorteremulator
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
            var serilogLogger = 

            services.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace);
                builder.AddSerilog(
                    logger: new LoggerConfiguration().WriteTo.RollingFile("Logs/eds.sorteremulator.log").CreateLogger(), 
                    dispose: true);
            });

            services.AddCors(o => o.AddPolicy("AllowAllOrigin", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));
            services.AddSignalR();

            services.AddControllers().AddNewtonsoftJson(); 

            services.AddSwaggerGen();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "WebClient";
            });

        }
        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAllOrigin");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<TrackingHub>("api/TrackingHub");
                endpoints.MapHub<ParcelsHub>("api/ParcelsHub");
                endpoints.MapHub<NodesHub>("api/NodesHub");
                endpoints.MapHub<ActionsHub>("api/ActionsHub");
                endpoints.MapHub<PhysicsHub>("api/PhysicsHub");

            });
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "WebClient";
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<CommunicationManager>().As<ICommunicationManager>();
            builder.RegisterType<TCPSocket>();

            builder.RegisterType<ProcessorFactory>().As<IProcessorFactory>();
            builder.RegisterType<DestinationReplyMessageProcessor>();
            builder.RegisterType<RemoteControlMessageProcessor>();
            builder.RegisterType<KeepAliveRequestMessageProcessor>();
            builder.RegisterType<KeepAliveReplyMessageProcessor>();
            builder.RegisterType<NullMessageProcessor>();

            builder.RegisterType<NodeActionFactory>().As<INodeActionFactory>();
            builder.RegisterType<NodeDeviation>();
            builder.RegisterType<EntryPoint>();
            builder.RegisterType<ScannerDataReader>();
            builder.RegisterType<DestinationRequest>();
            builder.RegisterType<SortReport>();
            builder.RegisterType<DefaultNext>();
            builder.RegisterType<NoNext>();
            builder.RegisterType<Default>();
            builder.RegisterType<RemoteControlOut>();
            builder.RegisterType<RecirculationCounter>();
            builder.RegisterType<Sink>();

            builder.RegisterType<ConfigurationManager>().As<IConfigurationManager>().SingleInstance();
            // Register services:
            builder.RegisterType<PhysicsService>().As<IPhysicsService>().As<IStartable>().SingleInstance();
            builder.RegisterType<NodesService>().As<INodesService>().As<IStartable>().SingleInstance();
            builder.RegisterType<ParcelService>().As<IParcelService>().As<IStartable>().SingleInstance();
            builder.RegisterType<MessageService>().As<IMessageService>().As<IStartable>().SingleInstance();
            builder.RegisterType<SorterService>().As<ISorterService>().As<IStartable>().SingleInstance();
            builder.RegisterType<FileService>().As<IStartable>().SingleInstance();
        }

    }
}
