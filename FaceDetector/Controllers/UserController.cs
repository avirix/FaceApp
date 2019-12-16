using System;
using System.Collections.Generic;
using System.Linq;

using Dtos;

using FaceDetector.Abstractions.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FaceDetector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        //Constructor
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get all users in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<UserDto> GetAll()
        {
            var users = _userService.GetAll();
            return users.ToList();
        }

        /// <summary>
        /// Get specific user by id
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public UserDto Get(Guid id)
        {
            return _userService.GetById(id);
        }
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="userDto">User object</param>
        /// <returns></returns>
        [HttpPost]
        public UserDto Post([FromBody] UserDto userDto)
        {
            var user = _userService.Create(userDto);
            return user;
        }

        /// <summary>
        /// Delete specific user by id
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Update specific user by id
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <param name="userDto">User object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]UserDto userDto)
        {
            var user = _userService.Update(id, userDto);
            return Ok(user);
        }
    }
}