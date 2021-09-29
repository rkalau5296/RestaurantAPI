using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    public class ReasturantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public ReasturantController(IRestaurantService restaurantService)
        {            
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {           

            return Ok(_restaurantService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<RestaurantDto>> Get([FromRoute] int id)
        {
            
            return Ok(_restaurantService.GetById(id));

        }

        [HttpPost]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {           

            return Created($"/api/restaurant/{_restaurantService.Create(dto)}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
             _restaurantService.Delete(id);
            
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Update ([FromBody] UpdateRestaurantDto dto, [FromRoute] int id)
        {            
             _restaurantService.Update(id, dto);

            return NotFound();
        }
    }
}
