using CocktailsIdeas.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocktailsIdeas.Server.Services
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Cocktail>> GetItemsAsync(string queryString);
    }
}
