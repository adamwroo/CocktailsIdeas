using CocktailsIdeas.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsIdeas.Server.Services
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Cocktail>> GetItemsAsync(string queryString);
    }
}
