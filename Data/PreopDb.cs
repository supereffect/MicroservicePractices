using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PreopDb
    {
        //DepdencenyInject. kullanamayız static class. Bu static sınıf sql server db'de migrations generate etmek için kullanılacak. Prod çıkmaz burası...
        public static void PreopPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            };
        }
        //in memory db olduğu için startta seed data basacağız.
        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Data Seed start");
                
                context.Platforms.AddRange(
                    new Platform()
                    {
                        Name = "Dotnet",
                        Publisher = "Microsoft",
                        Cost = " Free"
                    },
                    new Platform()
                    {
                        Name = "SQL Server Express",
                        Publisher = "Microsoft",
                        Cost = " Free"
                    },
                    new Platform()
                    {
                        Name = "Kubernetes",
                        Publisher = "Cloud Native Computing Foundation",
                        Cost = " Free"
                    }
                );

                context.SaveChanges();

            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}