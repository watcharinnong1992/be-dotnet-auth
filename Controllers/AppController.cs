using System;
using dotnet_auth.Models.Users;
using dotnet_auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_auth.Controllers
{
    [Route("api")]
    public class AppController : ControllerBase
    {

        public AppController()
        {
        }


        [HttpGet()]
        public IActionResult Hello()
        {
            return Ok("hello dotne-auth");
        }
    }
}

