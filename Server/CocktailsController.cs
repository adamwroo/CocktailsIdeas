using CocktailsIdeas.Server.Services;
using CocktailsIdeas.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsIdeas.Server
{
    [Route("cocktails")]
    [ApiController]
    public class CocktailsController : Controller
    {
        private readonly ICosmosDbService _cosmosDbService;

        public CocktailsController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cocktail>>> GetCocktails()
        {
            return (await _cosmosDbService.GetItemsAsync("SELECT * FROM c")).ToList();

            /*var dummyCocktailList = new List<Cocktail>
            {
                new Cocktail {Id = "1", Name = "Cuba Libre"},
                new Cocktail {Id = "2", Name = "Mojito"}
            };

            return await Task.FromResult(dummyCocktailList);*/
        }
    }
}
