using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Graph2.Channels;
using Graph2.Channels.Interfaces;
using Graph2.Channels.Vectors;
using Graph2.GraphQL;
using Graph2.GraphQL.Types;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Graph2
{
public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) 
        => Configuration = configuration;

    // This method gets called by the runtime. 
    // Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        services.AddSingleton<IDBAccess, DatabaseConnection>();

        services.AddSingleton<CustomerVector>();
        services.AddSingleton<OrderVector>();

        services.AddSingleton<CustomerType>();
        services.AddSingleton<OrderType>();

        services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
        services.AddScoped<OmniSchema>();
        services.AddGraphQL(o => { o.ExposeExceptions = true; })
                .AddGraphTypes(ServiceLifetime.Scoped);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseGraphQL<OmniSchema>(); // Default to api/GraphQL
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
}
}
