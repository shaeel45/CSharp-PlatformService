using PlatformServices.Models;

namespace PlatformServices.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetRequiredService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext appDbContext, bool isProd)
        {
            if(!appDbContext.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                appDbContext.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" },
                    new Platform() { Name = "Kafka", Publisher = "Kafka Microservices", Cost = "Free" }
                );

                appDbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}