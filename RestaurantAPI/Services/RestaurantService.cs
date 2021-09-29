using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantAPI.Controllers;
using RestaurantAPI.Entities;
using RestaurantAPI.Exceptions;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantDbContext _dbContex;

        private readonly IMapper _mapper;
        private readonly ILogger<RestaurantService> _logger;

        public RestaurantService(RestaurantDbContext dbContex, IMapper mapper, ILogger<RestaurantService> logger)
        {
            _dbContex = dbContex;
            _mapper = mapper;
            _logger = logger;
        }
        public RestaurantDto GetById(int id)
        {
            Restaurant restaurant = _dbContex
               .Restaurants
               .Include(restaurants => restaurants.Address)
               .Include(restaurants => restaurants.Dishes)
               .FirstOrDefault(r => r.Id == id);

            if (restaurant is null)
                throw new NotFoundException("Restaurant not found");

            var restaurantsDtos = _mapper.Map<RestaurantDto>(restaurant);
            return restaurantsDtos;
        }

        public IEnumerable<RestaurantDto> GetAll()
        {
            var restaurants = _dbContex
               .Restaurants
               .Include(restaurants => restaurants.Address)
               .Include(restaurants => restaurants.Dishes)
               .ToList();

            var restaurantsDtos = _mapper.Map<List<RestaurantDto>>(restaurants);

            return restaurantsDtos;
        }

        public int Create(CreateRestaurantDto dto)
        {           
            var restaurant = _mapper.Map<Restaurant>(dto);
            _dbContex.Restaurants.Add(restaurant);
            _dbContex.SaveChanges();
            return restaurant.Id;
        }

        public void Delete(int id)
        {
            _logger.LogError($"Restaurant with id: {id} DELETE action invoked");
            var restaurant = _dbContex
                .Restaurants
                .FirstOrDefault(r => r.Id == id);
            
            if (restaurant is null)
                throw new NotFoundException("Restaurant not found");

            _dbContex.Restaurants.Remove(restaurant);
            _dbContex.SaveChanges();
          
        }

        public void Update(int id, UpdateRestaurantDto dto)
        {
            var restaurant = _dbContex
                 .Restaurants
                 .FirstOrDefault(r => r.Id == id);

            if (restaurant is null)
                throw new NotFoundException("Restaurant not found");

            restaurant.Name = dto.Name;
            restaurant.Description = dto.Description;
            restaurant.HasDelivery = dto.HasDelivery;
            _dbContex.SaveChanges();
           
        }


    }
}
