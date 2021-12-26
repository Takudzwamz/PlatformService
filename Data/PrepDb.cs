using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
           using( var serviceScope = app.ApplicationServices.CreateScope())
           {
               SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
           } 
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data...");

                context.Platforms.AddRange(
                new Platform()
                {
                    Name = "PlayStation 4",
                    Publisher = "Sony",
                    Cost = "100"
                },
                new Platform()
                {
                    Name = "Xbox One",
                    Publisher = "Microsoft",
                    Cost = "100"
                },
                new Platform()
                {
                    Name = "Nintendo Switch",
                    Publisher = "Nintendo",
                    Cost = "100"
                }
            );

            context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We aleady have  Data");
            }
        }
    }
}