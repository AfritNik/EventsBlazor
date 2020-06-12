using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NI.Helpers.Blazor.Modal;
//using NikEventBlazor.Client.Helpers;
//using NikEventBlazor.Client.Repository;

namespace NikEventBlazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            ConfigureServices(builder.Services);
            await builder.Build().RunAsync();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            
            //services.AddBaseAddressHttpClient();
            services.AddScoped<IModalService, ModalService>();
            //services.AddScoped<IHttpService, HttpService>();
            //services.AddScoped<INikEventRepository, NikEventRepository>();
            services.AddDevExpressBlazor();
            //services.AddTransient<IRepository, RepositoryInMemory>();
        }
    }
}
