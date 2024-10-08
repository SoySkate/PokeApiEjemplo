using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        //Aqui llamamos las funciones de la Interface
        private readonly DataContext _context;

        public PokemonRepository(DataContext context) 
        {
            _context = context;
        }

        //Creamos un pokemon
        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            //asignamos el owner del pokemon
            var pokemonOwnerEntity = _context.Owners.Where(a=>a.Id==ownerId).FirstOrDefault();
            //le asignamos la category del pokemon
            var category = _context.Categories.Where(c=>c.Id==categoryId).FirstOrDefault();

            //Creamos un Pokemon owner con el owner y su pokemon
            var pokemonOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon
            };
            //añadimos el pokemonOwner a la DB
            _context.Add(pokemonOwner);

            //Creamos un PokemonCategory con su categoria y el pokemon
            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon = pokemon
            };
            _context.Add(pokemonCategory);

            return Save();
        }

        public bool DeletePokemon(Pokemon pokemon)
        {
            _context.Remove(pokemon);
            return Save();
        }

        //Recogemos el pokemon con el mismo id
        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        //Recogemos el pokemon con el mismo nombre
        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        //Recogeomos/Calculamos el rattting del pokemon con el id del pokemon
        public decimal GetPokemonRating(int pokeId)
        {
            var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeId);
            if (review.Count() <= 0)
                return 0;
            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        //Recogemos la lista entera de todos los pokemon
        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemons.OrderBy(p=>p.Id).ToList();
        }

        //Recogemos un bool true si existe el pokemon con el id indicado o false si no
        public bool PokemonExists(int pokeId)
        {
           return _context.Pokemons.Any(p=>p.Id == pokeId);
        }

        public bool Save()
        {
            var saved =  _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UptadePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            _context.Update(pokemon);
            return Save();

        }
    }
}
