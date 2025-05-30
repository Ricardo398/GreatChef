using GreatChef.Models;
using GreatChef.Repositories;

namespace GreatChef.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            // Garante que o banco de dados foi criado
            await context.Database.EnsureCreatedAsync();

            // Verifica se já existem dados
            if (context.Restaurants.Any())
            {
                return; // O banco já foi inicializado
            }

            // Cria um restaurante de teste
            var restaurant = new Restaurant
            {
                Name = "Burger Palace",
                Description = "O melhor hambúrguer artesanal da cidade!",
                Address = "Rua das Flores, 123",
                Phone = "(11) 99999-9999",
                Email = "contato@burgerpalace.com",
                ImageUrl = "https://images.unsplash.com/photo-1517248135467-4c7edcad34c4?w=1920&auto=format&fit=crop&q=80",
                CreatedAt = DateTime.UtcNow
            };

            context.Restaurants.Add(restaurant);
            await context.SaveChangesAsync();

            // Cria itens do menu
            var menuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Name = "Classic Burger",
                    Description = "Hambúrguer artesanal com queijo, alface, tomate e molho especial",
                    Price = 25.90m,
                    Category = "Burgers",
                    ImageUrl = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=800&auto=format&fit=crop&q=80",
                    IsAvailable = true,
                    RestaurantId = restaurant.Id,
                    CreatedAt = DateTime.UtcNow
                },
                new MenuItem
                {
                    Name = "Cheese Fries",
                    Description = "Batata frita crocante com queijo cheddar derretido",
                    Price = 15.90m,
                    Category = "Sides",
                    ImageUrl = "https://images.unsplash.com/photo-1573080496219-bb080dd4f877?w=800&auto=format&fit=crop&q=80",
                    IsAvailable = true,
                    RestaurantId = restaurant.Id,
                    CreatedAt = DateTime.UtcNow
                },
                new MenuItem
                {
                    Name = "Chocolate Shake",
                    Description = "Milk shake cremoso de chocolate com chantilly",
                    Price = 12.90m,
                    Category = "Drinks",
                    ImageUrl = "https://images.unsplash.com/photo-1577805947697-89e18249d767?w=800&auto=format&fit=crop&q=80",
                    IsAvailable = true,
                    RestaurantId = restaurant.Id,
                    CreatedAt = DateTime.UtcNow
                }
            };

            context.MenuItems.AddRange(menuItems);
            await context.SaveChangesAsync();

            // Cria alguns pedidos de teste
            var orders = new List<Order>
            {
                new Order
                {
                    RestaurantId = restaurant.Id,
                    CustomerName = "João Silva",
                    CustomerEmail = "joao@email.com",
                    CustomerPhone = "(11) 98888-8888",
                    Status = OrderStatus.Pending,
                    TotalAmount = 41.80m,
                    CreatedAt = DateTime.UtcNow,
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            MenuItemId = menuItems[0].Id,
                            Quantity = 1,
                            UnitPrice = menuItems[0].Price,
                            Subtotal = menuItems[0].Price
                        },
                        new OrderItem
                        {
                            MenuItemId = menuItems[1].Id,
                            Quantity = 1,
                            UnitPrice = menuItems[1].Price,
                            Subtotal = menuItems[1].Price
                        }
                    }
                },
                new Order
                {
                    RestaurantId = restaurant.Id,
                    CustomerName = "Maria Santos",
                    CustomerEmail = "maria@email.com",
                    CustomerPhone = "(11) 97777-7777",
                    Status = OrderStatus.Completed,
                    TotalAmount = 38.80m,
                    CreatedAt = DateTime.UtcNow.AddHours(-2),
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            MenuItemId = menuItems[0].Id,
                            Quantity = 1,
                            UnitPrice = menuItems[0].Price,
                            Subtotal = menuItems[0].Price
                        },
                        new OrderItem
                        {
                            MenuItemId = menuItems[2].Id,
                            Quantity = 1,
                            UnitPrice = menuItems[2].Price,
                            Subtotal = menuItems[2].Price
                        }
                    }
                }
            };

            context.Orders.AddRange(orders);
            await context.SaveChangesAsync();
        }
    }
} 