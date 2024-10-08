namespace PokemonReviewApp.Models
{
    //This is a JOin table for the relationship MAnyto Many  
    public class PokemonCategory
    {
        public int PokemonId { get; set; }
        public int CategoryId { get; set; }
        public Pokemon Pokemon { get; set; }
        public Category Category { get; set; }
    }
}
