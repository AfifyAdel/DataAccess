using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessAPI.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [Route("api/Users/GetUsers")]
        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            try
            {
                return await userRepository.GetUsers();
            }
            catch (Exception ex)
            {
                return new List<User>() ;
            }
        }
        [Route("api/Users/AddUser")]
        [HttpPost]
        public async Task<bool> AddUser([FromBody] User user)
        {
            try
            {
                return await userRepository.Insert(user);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
