using AvicoApp.Data;
using AvicoApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

namespace Avico.Tests
{
    // https://stackoverflow.com/questions/50921675/dependency-injection-in-xunit-project
    public class InMemoryDbFixture
    {

        public InMemoryDbFixture()
        {
            // var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            //     .UseInMemoryDatabase(Guid.NewGuid().ToString())
            //     .EnableSensitiveDataLogging()
            //     .Options;
        //     var configuration = GetIConfigurationRoot(null);

        //     var serviceCollection = new ServiceCollection();
        //     serviceCollection.AddDbContext<ApplicationDbContext>(options =>
        //         options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
        //     // serviceCollection.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();
                    
        //     serviceCollection.AddSingleton<HotelServices>();

        //     ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }

    //     private static IConfigurationRoot GetIConfigurationRoot(string outputPath)
    //     {            
    //         return new ConfigurationBuilder()
    //             .SetBasePath(outputPath)
    //             .AddJsonFile("appsettings.json", optional: true)
    //             .Build();
    //     }
    }
}
