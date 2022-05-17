using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Models;
using Core.Models.OrderAggregate;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infrastructure.Data.Contexts;

public class StoreContextSeed
{
    public static async Task SeedAsync(DataContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!context.ProductBrands.Any())
            {
                var brandsData =
                    File.ReadAllText(
                        "C:/Users/Ingen/RiderProjects/SkinetMarket/Infrastructure/Data/SeedData/brands.json");

                var brands = JsonConvert.DeserializeObject<List<ProductBrand>>(brandsData);

                foreach (var item in brands) context.ProductBrands.Add(item);

                await context.SaveChangesAsync();
            }

            if (!context.ProductTypes.Any())
            {
                var typesData =
                    File.ReadAllText(
                        "C:/Users/Ingen/RiderProjects/SkinetMarket/Infrastructure/Data/SeedData/types.json");

                var types = JsonConvert.DeserializeObject<List<ProductType>>(typesData);

                foreach (var item in types) context.ProductTypes.Add(item);

                await context.SaveChangesAsync();
            }

            if (!context.Products.Any())
            {
                var productsData =
                    File.ReadAllText(
                        "C:/Users/Ingen/RiderProjects/SkinetMarket/Infrastructure/Data/SeedData/Products.json");

                var products = JsonConvert.DeserializeObject<List<Product>>(productsData);

                foreach (var item in products) context.Products.Add(item);

                await context.SaveChangesAsync();
            }

            if (!context.DeliveryMethods.Any())
            {
                var dmData =
                    File.ReadAllText(
                        "C:/Users/Ingen/RiderProjects/SkinetMarket/Infrastructure/Data/SeedData/delivery.json");

                var methods = JsonConvert.DeserializeObject<List<DeliveryMethod>>(dmData);

                foreach (var item in methods) context.DeliveryMethods.Add(item);

                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<StoreContextSeed>();
            logger.LogError(ex.Message);
        }
    }
}