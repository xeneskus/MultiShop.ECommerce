﻿using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        public Task<bool> SignIn(SignInDto signInDto)
        {
            throw new NotImplementedException();
        }
    }
}