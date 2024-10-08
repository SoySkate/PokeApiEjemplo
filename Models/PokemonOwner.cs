namespace PokemonReviewApp.Models
{
    //This is a JOin table for the relationship MAnyto Many
    public class PokemonOwner
    {
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }
        public Pokemon Pokemon { get; set; }
        public Owner Owner { get; set; }
    }
}
