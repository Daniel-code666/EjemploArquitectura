using WebApi.Interfaces;

namespace WebApi.Integrations
{
    public class PokeApiIntegration : IPokeApiIntegration
    {
        Task<IEnumerable<string>> IPokeApiIntegration.GetPokemonNames()
        {
            // hace petición a un servicio externo y se devuelven los resultados
            List<string> poke_names = ["Pikachu", "Nombre de pokemon 1", "nombre de pokemon 2"];

            return Task.FromResult(poke_names.AsEnumerable());
        }
    }
}
