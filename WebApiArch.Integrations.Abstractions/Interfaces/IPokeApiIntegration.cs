namespace WebApi.Interfaces
{
    public interface IPokeApiIntegration
    {
        Task<IEnumerable<string>> GetPokemonNames();
    }
}
