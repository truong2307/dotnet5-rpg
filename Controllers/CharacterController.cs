using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet5_rpg.Models;
using dotnet5_rpg.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet5_rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
       private readonly ICharacterService _CharacterService;
       public CharacterController(ICharacterService characterService)
       {
           _CharacterService = characterService;
       }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> Get()
        {
            return Ok(await _CharacterService.GetAllCharacters());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Character>>> GetSingle(int id)
        {
            return Ok(await _CharacterService.GetCharacterById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharacter (Character character)
        {
            return Ok(await _CharacterService.AddCharacter(character));
        }
    }
}