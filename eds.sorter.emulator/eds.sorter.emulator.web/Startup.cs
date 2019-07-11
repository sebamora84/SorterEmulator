using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dependencies;
using eds.sorter.emulator.services.Services;
using eds.sorter.emulator.services.Services.Interfaces;
using eds.sorter.emulator.web.Api;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace eds.sorter.emulator.web
{
    public class Startup
    {
        private List<IService> _services;

        public Startup(List<IService> services)
        {
            _services = services;
        }

        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            var dependencyResolver =new OverriddenWebApiDependencyResolver(config.DependencyResolver)
                .Add(typeof(PhysicsController), () => new PhysicsController(
                    _services.First(s => s is IPhysicsService) as IPhysicsService))
                .Add(typeof(TrackingController), () => new TrackingController(
                    _services.First(s => s is IPhysicsService) as IPhysicsService))
                .Add(typeof(ParcelsController), () => new ParcelsController(
                    _services.First(s => s is IPhysicsService) as IPhysicsService,
                    _services.First(s => s is IParcelService) as IParcelService,
                    _services.First(s => s is INodesService) as INodesService))
                .Add(typeof(NodesController), () => new NodesController(
                    _services.First(s => s is INodesService) as INodesService))
                .Add(typeof(SorterController), () => new SorterController(
                    _services.First(s => s is INodesService) as INodesService));
            config.DependencyResolver = dependencyResolver;

            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            appBuilder.UseWebApi(config);
            appBuilder.UseCors(CorsOptions.AllowAll);

            // Route all unknown requests to app root
            appBuilder.Use(async (context, next) =>
            {
                await next();

                // If there's no available file and the request doesn't contain an extension, we're probably trying to access a page.
                // Rewrite request to use app root
                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path =  new PathString("./index.html"); // Put your Angular root page here 
                    context.Response.StatusCode = 200; // Make sure we update the status code, otherwise it returns 404
                    await next();
                }
            }).UseFileServer(new FileServerOptions
            {
                RequestPath = new PathString(string.Empty),
                FileSystem = new PhysicalFileSystem("./WebClient"),
                EnableDirectoryBrowsing = true
            }).UseStaticFiles();
            appBuilder.UseStageMarker(PipelineStage.MapHandler);
        }
        public class OverriddenWebApiDependencyResolver : WebApiOverrideDependency<IDependencyResolver>, IDependencyResolver
        {
            public OverriddenWebApiDependencyResolver Add(Type serviceType, Func<object> initializer)
            {
                provided.Add(serviceType, initializer);
                return this;
            }
            public IDependencyScope BeginScope() => new Scope(inner.BeginScope(), provided);
            public OverriddenWebApiDependencyResolver(IDependencyResolver inner) : base(inner, new Dictionary<Type, Func<object>>()) { }
            public class Scope : WebApiOverrideDependency<IDependencyScope>, IDependencyScope
            {
                public Scope(IDependencyScope inner, IDictionary<Type, Func<object>> provided) : base(inner, provided) { }
            }
        }
        public abstract class WebApiOverrideDependency<T> : IDependencyScope where T : IDependencyScope
        {
            public void Dispose() => inner.Dispose();
            public object GetService(Type serviceType)
            {
                Func<object> res;
                return provided.TryGetValue(serviceType, out res) ? res() : inner.GetService(serviceType);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                Func<object> res;
                return inner.GetServices(serviceType).Concat(provided.TryGetValue(serviceType, out res) ? new[] { res() } : Enumerable.Empty<object>());
            }
            protected readonly T inner;
            protected readonly IDictionary<Type, Func<object>> provided;
            public WebApiOverrideDependency(T inner, IDictionary<Type, Func<object>> provided)
            {
                this.inner = inner;
                this.provided = provided;
            }

        }
    }
}
