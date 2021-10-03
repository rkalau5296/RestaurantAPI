using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Interfaces
{
    public interface IDishService
    {
        int Create(int restaurantId, CreateDishDto dto);
        List<DishDto> GetAll(int restaurantId);
        DishDto GetById(int restaurantId, int dishId);
        void RemoveAll(int restaurantId);
    }
}
