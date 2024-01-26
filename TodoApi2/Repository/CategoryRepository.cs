using TodoApi2.Data;
using TodoApi2.Interfaces;
using TodoApi2.Models;

namespace TodoApi2.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext? _context;
        public CategoryRepository(DataContext context)
        {
            this._context = context;
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(e => e.CategoryId == categoryId)
                .Select(e => e.Pokemon).ToList();
        }
    }
}
