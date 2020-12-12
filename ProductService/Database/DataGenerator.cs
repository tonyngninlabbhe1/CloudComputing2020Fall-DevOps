
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ProductDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ProductDbContext>>()))
        {
            if (context.Products.Any())
            {
                return; // Data was already seeded
            }

            context.Products.AddRange(
                new Product
                {
                    ProductId = 1,
                    Name = "PS5",
                    Price = 899.95m,
                    Count = 4
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Sofa",
                    Price = 299.95m,
                    Count = 10
                }
            );

            context.SaveChanges();
        }
    }
}