using RestaurantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {            
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name= "User"
                },
                new Role()
                {
                    Name= "Manager"
                },
                new Role()
                {
                    Name= "Admin"
                },
            };

            return roles;
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            List<Restaurant> restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC (short for Kentucky Fired Chicken) is an American fast food restaurant chain headquartered",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Price = 10.30M,
                        },
                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 5.30M,
                        }
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Długa 6",
                        PostalCode = "00-950",
                        Region = "Poland",
                        Country="Poland"

                    }
                },
                new Restaurant()
                {
                    Name = "McDonalds",
                    Category = "Fast Food",
                    Description = "McDonalds is an American fast food restaurant.",
                    ContactEmail = "contact@mcdonalds.com",
                    HasDelivery = true,
                    Opinion = "positive",
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Hamburger",
                            Price = 10.30M,
                        },
                        new Dish()
                        {
                            Name = "Cheeseburger",
                            Price = 5.30M,
                        }
                    },
                    Address = new Address()
                    {
                        City = "Warszawa",
                        Street = "Krzywa 1",
                        PostalCode = "00-950",
                        Region = "Poland",
                        Country="Poland"
                    }
                },
                new Restaurant()
                {
                    Name = "Pizza Hut",
                    Category = "Fast Food",
                    Description = "Pizza Hut is an American pizza restaurant.",
                    ContactEmail = "contact@pizzahut.com",
                    HasDelivery = true,
                    Opinion = "negative",
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Margarita",
                            Price = 12.30M,
                        },
                        new Dish()
                        {
                            Name = "Pepperoni",
                            Price = 5.30M,
                        }
                    },
                    Address = new Address()
                    {
                        City = "Gdańsk",
                        Street = "Targ drzewny 1",
                        PostalCode = "00-950",
                        Region = "Poland",
                        Country="Poland"
                    }
                },
                new Restaurant()
                {
                    Name = "Burger KIng",
                    Category = "Fast Food",
                    Description = "Pizza Hut is an American pizza restaurant.",
                    ContactEmail = "contact@pizzahut.com",
                    HasDelivery = true,
                    Opinion = "negative",
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "BigBurger",
                            Price = 12.30M,
                        },
                        new Dish()
                        {
                            Name = "MacBUrger",
                            Price = 5.30M,
                        }
                    },
                    Address = new Address()
                    {
                        City = "Opole",
                        Street = "Sadowa 5",
                        PostalCode = "00-950",
                        Region = "Poland",
                        Country="Poland"
                    }
                }
            };
            return restaurants;
        }
    }
}
