using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class TiendaContextSeed
    {
        public static async Task SeedAsync(TiendaContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductoBrands.Any())
                {
                    var brandsData = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductoBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        context.ProductoBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.ProductoTypes.Any())
                {
                    var typesData = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductoType>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProductoTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Productos.Any())
                {
                    var productosData = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    var productos = JsonSerializer.Deserialize<List<Producto>>(productosData);

                    foreach (var item in productos)
                    {
                        context.Productos.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                
                var logger = loggerFactory.CreateLogger<TiendaContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}