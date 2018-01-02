namespace ProductsShop.App
{
    using Newtonsoft.Json;
    using ProductsShop.Data;
    using ProductsShop.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class Startup
    {
        public static void Main()
        {
            JSONProcessing();

            XMLProcessing();
        }

        private static string ImportUsersFromXML()
        {
            var xmlString = File.ReadAllText("Files/users.xml");

            var xmlDoc = XDocument.Parse(xmlString);

            var elements = xmlDoc.Root.Elements();

            var users = new List<User>();

            foreach (var element in elements)
            {
                var firstName = element.Attribute("firstName")?.Value;

                var lastName = element.Attribute("lastName")?.Value;

                int? age = null;

                if(element.Attribute("age") != null)
                {
                    age = int.Parse(element.Attribute("age").Value);
                }

                var user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age
                };

                users.Add(user);
            }

            using (var db = new ProductsShopContext())
            {
                db
                    .Users
                    .AddRange(users);

                db.SaveChanges();
            }

            return $"{users.Count} users added";
        }

        private static void XMLProcessing()
        {
            // ImportUsersFromXML();
        }

        private static void JSONProcessing()
        {
            // ImportUsersFromJson();

            // ImportCategoriesFromJson();

            // ImportProductsFromJson();

            // SetCategories();

            // GetProductsInRange();

            // GetCategoriesByProductCount();

            // GetAllUsersWithMoreThanTwoSells();
        }

        private static void GetAllUsersWithMoreThanTwoSells()
        {
            using (var db = new ProductsShopContext())
            {
                var users = db
                    .Users
                    .Where(u => u.ProductSold.Count > 1)
                    .OrderByDescending(u => u.ProductSold.Count)
                    .ThenBy(u => u.LastName)
                    .Select(u => new
                    {
                        u.FirstName,
                        u.LastName,
                        u.Age,
                        Products = u.ProductSold.Select(ps => new
                        {
                            ps.Name,
                            ps.Price
                        })
                    })
                    .ToArray();

                var jsonString = JsonConvert.SerializeObject(users,Formatting.Indented
                    ,new JsonSerializerSettings()
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore
                    });

                File.WriteAllText("Files/userswithproducts.json", jsonString);
            }
        }

        private static void GetCategoriesByProductCount()
        {
            using(var db = new ProductsShopContext())
            {
                var categories = db
                    .Categories
                    .OrderBy(c => c.Name)
                    .Select(c => new
                    {
                        c.Name,
                        TotalProducts = c.Products.Count,
                        AverageProductPrice = c.Products.Select(pr => pr.Product.Price).Average(),
                        TotalProductPrice = c.Products.Select(pr => pr.Product.Price).Sum()
                    })
                    .ToList();

                var jsonString = JsonConvert.SerializeObject(categories, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore
                    });

                File.WriteAllText("Files/categoriesbyproducts.json", jsonString);
            }
        }

        private static void GetProductsInRange()
        {
            using (var db = new ProductsShopContext())
            {
                var products = db
                    .Products
                    .Where(pr => pr.Price >= 500 && pr.Price <= 1000)
                    .OrderBy(pr=>pr.Price)
                    .Select(pr => new
                    {
                        pr.Name,
                        pr.Price,
                        Seller = $"{pr.Seller.FirstName} {pr.Seller.LastName}"
                    })
                    .ToList();

                var jsonString = JsonConvert.SerializeObject(products, Formatting.Indented
                    ,new JsonSerializerSettings()
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore
                    });

                File.WriteAllText("Files/productsinrange.json", jsonString);
            }
        }

        private static string SetCategories()
        {
            using (var db = new ProductsShopContext())
            {
                var productIds = db.Products.Select(pr => pr.Id).ToArray();
                var categoryIds = db.Categories.Select(c => c.Id).ToArray();

                var rnd = new Random();

                var categoryProducts = new List<CategoryProduct>();

                foreach (var productId in productIds)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        var index = rnd.Next(0, categoryIds.Length);

                        if(categoryProducts.Any(cp=>cp.ProductId == productId && cp.CategoryId == categoryIds[index]))
                        {
                            continue;
                        }

                        var categoryProduct = new CategoryProduct
                        {
                            ProductId = productId,
                            CategoryId = categoryIds[index]
                        };

                        categoryProducts.Add(categoryProduct);
                    }
                }

                categoryProducts.GroupBy(cp => cp.ProductId).Distinct();

                db
                    .CategoryProducts
                    .AddRange(categoryProducts);

                db.SaveChanges();

                return $"{categoryProducts.Count} category products were added";
            }
        }

        private static string ImportProductsFromJson()
        {
            var products = ImportJSon<Product>("Files/products.json");

            var rnd = new Random();

            using (var db = new ProductsShopContext())
            {
                var userIds = db.Users.Select(u => u.Id).ToArray();

                foreach (var product in products)
                {
                    product.SellerId = userIds[rnd.Next(0, userIds.Length - 1)];
                }

                db
                    .Products
                    .AddRange(products);

                db.SaveChanges();
            }

            return $"{products.Length} products were added";
        }

        private static string ImportCategoriesFromJson()
        {
            var categories = ImportJSon<Category>("Files/categories.json");

            using(var db = new ProductsShopContext())
            {
                db
                    .Categories
                    .AddRange(categories);

                db.SaveChanges();
            }

            return $"{categories.Length} categories were added";
        }

        private static string ImportUsersFromJson()
        {
            var users = ImportJSon<User>("Files/users.json");

            using (var db = new ProductsShopContext())
            {
                db
                    .Users
                    .AddRange(users);

                db.SaveChanges();
            }

            return $"{users.Length} users were added";
        }

        private static T[] ImportJSon<T>(string path)
        {
            var jsonString = File.ReadAllText(path);

            var objects = JsonConvert.DeserializeObject<T[]>(jsonString);

            return objects;
        }
    }
}