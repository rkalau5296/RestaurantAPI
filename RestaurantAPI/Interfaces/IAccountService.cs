﻿using RestaurantAPI.Controllers;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Interfaces
{
    public interface IAccountService
    {
        public void RegisterUser(RegisterUserDto dto);
        public string GenerateJwt(LoginDto dto);
    }
}
