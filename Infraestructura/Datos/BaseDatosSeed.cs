using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.Extensions.Logging;

namespace Infraestructura.Datos
{
    public class BaseDatosSeed
    {
        public static async Task seedAsync(ApplicationDbContext context, ILoggerFactory loggerFactory){

            try
            {
                if(!context.Pais.Any()){
                    var paisData = File.ReadAllText("../Infraestructura/Datos/SeedData/paises.json");
                    var paises = JsonSerializer.Deserialize<List<Pais>>(paisData);

                    foreach(var item in paises){
                        await context.Pais.AddAsync(item);
                    }

                    await context.SaveChangesAsync();
                }

                if(!context.Categoria.Any()){
                    var categoriaData = File.ReadAllText("../Infraestructura/Datos/SeedData/categorias.json");
                    var categoria = JsonSerializer.Deserialize<List<Categoria>>(categoriaData);

                    foreach(var item in categoria){
                        await context.Categoria.AddAsync(item);
                    }

                    await context.SaveChangesAsync();
                }

                 if(!context.Lugar.Any()){
                    var lugarData = File.ReadAllText("../Infraestructura/Datos/SeedData/lugares.json");
                    var lugar = JsonSerializer.Deserialize<List<Lugar>>(lugarData);

                    foreach(var item in lugar){
                        await context.Lugar.AddAsync(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {
                
                var logger = loggerFactory.CreateLogger<BaseDatosSeed>();
                logger.LogError(ex.Message);
            }

        }
    }
}