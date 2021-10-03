using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class DishServices : IDishService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;
        public DishServices(RestaurantDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public int Create (int restaurantId, CreateDishDto dto) 
        {
            var restaurant = GetResturantById(restaurantId);

            var dishEntity = _mapper.Map<Dish>(dto);
            dishEntity.RestaurantId = restaurantId;

            _dbContext.Dishes.Add(dishEntity);
            _dbContext.SaveChanges();

            return dishEntity.Id;
        }

        public DishDto GetById(int restaurantId, int dishId)
        {
            var restaurant = GetResturantById(restaurantId);
            var dish = _dbContext.Dishes.FirstOrDefault(d => d.Id == dishId);
            if(dish is null|| dish.RestaurantId != restaurantId)
                throw new NotFoundException("Dish not found");

            var dishDto = _mapper.Map<DishDto>(dish);
            return dishDto;
        }

        public List<DishDto> GetAll(int restaurantId) 
        {
            var restaurant = GetResturantById(restaurantId);

            var listOfDishesDto = _mapper.Map<List<DishDto>>(restaurant.Dishes);
            return listOfDishesDto;
        }

        public void RemoveAll(int restaurantId) 
        {
            var restaurant = GetResturantById(restaurantId);

            _dbContext.RemoveRange(restaurant.Dishes);
            _dbContext.SaveChanges();
        }
        

        private Restaurant GetResturantById(int restaurantId)
        {
            var restaurant = _dbContext
                .Restaurants
                .Include(r => r.Dishes)
                .FirstOrDefault(r => r.Id == restaurantId);

            if (restaurant is null)
                throw new NotFoundException("Resturant not found");

            return restaurant;
        }
    }
}
