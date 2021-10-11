using RestaurantAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Interfaces
{
    public interface IAccountService
    {
        public void RegisterUser(RegisterUserDto dto);
    }
}
