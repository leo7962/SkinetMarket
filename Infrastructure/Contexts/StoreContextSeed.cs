using Core.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(DataContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    string brandsData = File.ReadAllText("C:/Users/Ingen/source/repos/SkinetMarket/Infrastructure/SeedData/brands.json");

                    List<ProductBrand> brands = JsonConvert.DeserializeObject<List<ProductBrand>>(brandsData);

                    foreach (ProductBrand item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                if (!context.ProductTypes.Any())
                {
                    string typesData = File.ReadAllText("C:/Users/Ingen/source/repos/SkinetMarket/Infrastructure/SeedData/types.json");

                    List<ProductType> types = JsonConvert.DeserializeObject<List<ProductType>>(typesData);

                    foreach (ProductType item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                if (!context.Products.Any())
                {
                    string productsData = File.ReadAllText("C:/Users/Ingen/source/repos/SkinetMarket/Infrastructure/SeedData/Products.json");

                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(productsData);

                    foreach (Product item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                ILogger<StoreContextSeed> logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
