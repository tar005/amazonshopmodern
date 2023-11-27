using Ecommerce.Application.Models.Authorization;
using Ecommerce.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infraestructure.Persistence
{
    public class EcommerceDbContextData
    {
        public static async Task LoadDataAsync(EcommerceDbContext context, UserManager<Usuario> usuarioManager, RoleManager<IdentityRole> roleManager, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!roleManager.Roles.Any())
                {
                    await roleManager.CreateAsync(new IdentityRole(Role.ADMIN));
                    await roleManager.CreateAsync(new IdentityRole(Role.USER));
                }

                if(!usuarioManager.Users.Any())
                {
                    var usuarioAdmin = new Usuario
                    {
                        Nombre = "Vaxi",
                        Apellido = "Drez",
                        Email = "vaxi.drez.social@gmail.com",
                        UserName = "vaxi.drez",
                        Telefono = "985644644",
                        AvatarUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/vaxidrez.jpg?alt=media&token=14a28860-d149-461e-9c25-9774d7ac1b24"
                    };
                    await usuarioManager.CreateAsync(usuarioAdmin, "Password1234.");
                    await usuarioManager.AddToRoleAsync(usuarioAdmin,Role.ADMIN);

                    var usuario = new Usuario
                    {
                        Nombre = "Juan",
                        Apellido = "Perez",
                        Email = "juan.perez@gmail.com",
                        UserName = "juan.perez",
                        Telefono = "98563434534",
                        AvatarUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/avatar-1.webp?alt=media&token=58da3007-ff21-494d-a85c-25ffa758ff6d"
                    };
                    await usuarioManager.CreateAsync(usuario, "Password1234.");
                    await usuarioManager.AddToRoleAsync(usuario, Role.USER);
                }
                
                if(!context.Categories!.Any())
                {
                    var categoryData = File.ReadAllText("../Ecommerce.Infraestructure/Data/category.json");
                    var categories = JsonConvert.DeserializeObject<List<Category>>(categoryData);
                    await context.Categories!.AddRangeAsync(categories!);
                    await context.SaveChangesAsync();
                }

                if (!context.Products!.Any())
                {
                    var productData = File.ReadAllText("../Ecommerce.Infraestructure/Data/product.json");
                    var products = JsonConvert.DeserializeObject<List<Product>>(productData);
                    await context.Products!.AddRangeAsync(products!);
                    await context.SaveChangesAsync();
                }

                if (!context.Images!.Any())
                {
                    var imageData = File.ReadAllText("../Ecommerce.Infraestructure/Data/image.json");
                    var imagenes = JsonConvert.DeserializeObject<List<Image>>(imageData);
                    await context.Images!.AddRangeAsync(imagenes!);
                    await context.SaveChangesAsync();
                }

                if (!context.Reviews!.Any())
                {
                    var reviewData = File.ReadAllText("../Ecommerce.Infraestructure/Data/review.json");
                    var reviews = JsonConvert.DeserializeObject<List<Review>>(reviewData);
                    await context.Reviews!.AddRangeAsync(reviews!);
                    await context.SaveChangesAsync();
                }

                if (!context.Countries!.Any())
                {
                    var contriesData = File.ReadAllText("../Ecommerce.Infraestructure/Data/countries.json");
                    var countries = JsonConvert.DeserializeObject<List<Country>>(contriesData);
                    await context.Countries!.AddRangeAsync(countries!);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<EcommerceDbContextData>();
                logger.LogError(ex.Message);
            }
        }
    }
}
