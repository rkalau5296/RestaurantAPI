using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Controllers;
using RestaurantAPI.Entities;
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

        public RestaurantService(RestaurantDbContext dbContex, IMapper mapper)
        {
            _dbContex = dbContex;
            _mapper = mapper;

        }
        public RestaurantDto GetById(int id)
        {
            Restaurant restaurant = _dbContex
               .Restaurants
               .Include(restaurants => restaurants.Address)
               .Include(restaurants => restaurants.Dishes)
               .FirstOrDefault(r => r.Id == id);

            if (restaurant is null)
            {
                return null;
            }

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

        public bool Delete(int id)
        {
            var restaurant = _dbContex
                .Restaurants
                .FirstOrDefault(r => r.Id == id);
            
            if (restaurant is null) return false;

            _dbContex.Restaurants.Remove(restaurant);
            _dbContex.SaveChanges();

            return true;

        }

        public bool Update(int id, UpdateRestaurantDto dto)
        {
            var restaurant = _dbContex
                 .Restaurants
                 .FirstOrDefault(r => r.Id == id);

            if (restaurant is null) return false;

            restaurant.Name = dto.Name;
            restaurant.Description = dto.Description;
            restaurant.HasDelivery = dto.HasDelivery;
            _dbContex.SaveChanges();

            return true;
        }


    }
}
