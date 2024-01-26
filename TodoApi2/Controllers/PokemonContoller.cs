using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoApi2.Data;
using TodoApi2.Dto;
using TodoApi2.Interfaces;
using TodoApi2.Models;

namespace TodoApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonContoller : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public PokemonContoller(IPokemonRepository pokemonRepository, DataContext dataContext, 
        IMapper mapper) {
            this._pokemonRepository = pokemonRepository;
            this._dataContext = dataContext;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {

            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(pokemons);
        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
            {
                return NotFound();
            }
            var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemon);
        }

        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating (int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
            {
                return NotFound();
            }

            var rating = this._pokemonRepository.GetPokemonRating(pokeId);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(rating);
        }

    }
}
