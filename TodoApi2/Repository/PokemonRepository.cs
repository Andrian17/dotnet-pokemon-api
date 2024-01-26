using TodoApi2.Data;
using TodoApi2.Interfaces;
using TodoApi2.Models;

namespace TodoApi2.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext? _context;
        public PokemonRepository(DataContext dataContext) {
            this._context = dataContext;
        }
        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemons.OrderBy(p => p.Id).ToList();
            // return _context.Pokemons.ToList();
        }
        public Pokemon GetPokemon(int pokemonId)
        {
            return _context.Pokemons.Where(p => p.Id == pokemonId).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokemonId)
        {
            var review = _context.Reviews.Where(r => r.Pokemon.Id == pokemonId);
            if (review.Count() <= 0)
            {
                return 0;
            }
            return ((decimal) review.Sum(r => r.Rating) /  review.Count());
        }

        public bool PokemonExists(int pokemonId)
        {
            return _context.Pokemons.Any(p => p.Id == pokemonId);
        }
    }
}
