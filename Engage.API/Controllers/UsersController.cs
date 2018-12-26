using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Engage.API.Data;
using Engage.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Engage.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController: Controller
    {
        public UsersController(IEngageRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEngageRepository _repo { get; }
        public IMapper _mapper { get; }

        [HttpGet]
        public async Task<IActionResult> GetUsers(){
            var users = await _repo.GetUsers();
            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id){
            var user = await _repo.GetUser(id);
            var userToReturn = _mapper.Map<UserForDetailedDto>(user);
            return Ok(userToReturn);
        }
    }
}