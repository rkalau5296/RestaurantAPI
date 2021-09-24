using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    public class ReasturantController : ControllerBase
    {
        private readonly RestaurantDbContext _dbContex;
        private readonly IMapper _mapper;
        public ReasturantController(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContex = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetAll()
        {
            var restaurants = _dbContex
                .Restaurants
                
                .ToList();
            

            return Ok(restaurants);
        }
        //[HttpGet]
        //public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        //{
        //    var restaurants = _dbContex
        //        .Restaurants
        //        .Include(restaurants => restaurants.Address)
        //        .Include(restaurants => restaurants.Dishes)
        //        .ToList();

        //    var restaurantsDtos = _mapper.Map<List<RestaurantDto>>(restaurants);

        //    return Ok(restaurantsDtos);
        //}

        //[HttpGet("{id}")]
        //public ActionResult<IEnumerable<RestaurantDto>> Get([FromRoute] int id)
        //{
        //    Restaurant restaurant = _dbContex
        //        .Restaurants
        //        .Include(restaurants => restaurants.Address)
        //        .Include(restaurants => restaurants.Dishes)
        //        .FirstOrDefault(r => r.Id == id);

        //    if (restaurant is null)
        //    {
        //        return NotFound();
        //    }

        //    var restaurantsDtos = _mapper.Map<RestaurantDto>(restaurant);
        //    return Ok(restaurant);

        //}
    }
}
