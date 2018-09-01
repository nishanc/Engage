
using System.Threading.Tasks;
using Engage.API.Data;
using Engage.API.Dtos;
using Engage.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Engage.API.Controllers
{   
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto){
            
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await _repo.UserExists(userForRegisterDto.Username)) 
            ModelState.AddModelError("Username","Username already exists");

            // validate request
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var userToCreate = new User{
                Username = userForRegisterDto.Username
            };

            var createUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }
    }
}