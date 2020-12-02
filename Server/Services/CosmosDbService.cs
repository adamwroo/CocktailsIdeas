using CocktailsIdeas.Shared;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsIdeas.Server.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(CosmosClient dbClient, string databaseName, string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task<IEnumerable<Cocktail>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<Cocktail>(new QueryDefinition(queryString));
            List<Cocktail> results = new List<Cocktail>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }
    }
}
