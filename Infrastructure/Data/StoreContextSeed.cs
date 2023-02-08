

using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.ProductBrand.Any())
            {
                var brandsData = File.ReadAllText("C:\\LearningPath\\AngularWithNetCore\\EcommerceApp\\Infrastructure\\Data\\SeedData\\brands.json");
                var brands=JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrand.AddRange(brands);
            }
             if (!context.ProductType.Any())
            {
                var productTypes = File.ReadAllText("C:\\LearningPath\\AngularWithNetCore\\EcommerceApp\\Infrastructure\\Data\\SeedData\\types.json");
                var types=JsonSerializer.Deserialize<List<ProductType>>(productTypes);
                context.ProductType.AddRange(types);
            }
             if (!context.Products.Any())
            {
                var products = File.ReadAllText("C:\\LearningPath\\AngularWithNetCore\\EcommerceApp\\Infrastructure\\Data\\SeedData\\products.json");
                var desProducts=JsonSerializer.Deserialize<List<Product>>(products);
                context.Products.AddRange(desProducts);
            }
            if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}