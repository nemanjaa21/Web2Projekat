﻿using OnlineShop.DTO;

namespace OnlineShop.Common
{
    public interface IAutentifikacijaService
    {
        Task<string> Login(LoginDTO login);
    }
}