using Core.Models;
using Core.Models.OrderAggregate;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Infrastructure.Data.Contexts
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(DataContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if (!context.ProductBrands.Any())
                {
                    string brandsData =
                        File.ReadAllText(
                            "C:/Users/Ingen/source/repos/SkinetMarket/Infrastructure/Data/SeedData/brands.json");

                    List<ProductBrand> brands = JsonConvert.DeserializeObject<List<ProductBrand>>(brandsData);

                    foreach (ProductBrand item in brands) context.ProductBrands.Add(item);

                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    string typesData =
                        File.ReadAllText(
                            "C:/Users/Ingen/source/repos/SkinetMarket/Infrastructure/Data/SeedData/types.json");

                    List<ProductType> types = JsonConvert.DeserializeObject<List<ProductType>>(typesData);

                    foreach (ProductType item in types) context.ProductTypes.Add(item);

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    string productsData =
                        File.ReadAllText(
                            "C:/Users/Ingen/source/repos/SkinetMarket/Infrastructure/Data/SeedData/Products.json");

                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(productsData);

                    foreach (Product item in products) context.Products.Add(item);

                    await context.SaveChangesAsync();
                }

                if (!context.DeliveryMethods.Any())
                {
                    string dmData =
                        File.ReadAllText(
                            "C:/Users/Ingen/source/repos/SkinetMarket/Infrastructure/Data/SeedData/delivery.json");

                    List<DeliveryMethod> methods = JsonConvert.DeserializeObject<List<DeliveryMethod>>(dmData);

                    foreach (DeliveryMethod item in methods) context.DeliveryMethods.Add(item);

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