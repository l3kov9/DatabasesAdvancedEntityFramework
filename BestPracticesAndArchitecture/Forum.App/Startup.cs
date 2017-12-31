namespace Forum.App
{
    using Forum.Data;
    using Forum.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class Startup
    {
        public static void Main()
        {
            var serviceProvider = ConfigureServices();

            var userService = serviceProvider.GetService<IUserService>();
            userService.ById(5);
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<ForumDbContext>(
                options => options.UseSqlServer(Configuration.ConnectionString));
            
            serviceCollection.AddTransient<IUserService, UserService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
