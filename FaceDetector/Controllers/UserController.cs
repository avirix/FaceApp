using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaceDetector.Abstractions.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FaceDetector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
    }
}