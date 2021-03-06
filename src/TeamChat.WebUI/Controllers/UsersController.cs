﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamChat.Core.Interfaces.Service;
using TeamChat.Core.Model;
using TeamChat.WebUI.Model;
using AutoMapper;

namespace TeamChat.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<UserDTO> Get() => Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(_userService.List());

        [HttpGet("{id}")]
        public UserDTO Get(int id) => Mapper.Map<UserDTO>(_userService.FindById(id));

        [HttpPost]
        public void Post([FromBody]User user)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User user)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
