﻿using CocktailsIdeas.Server.Services;
using CocktailsIdeas.Shared;
using Microsoft.AspNetCore.Mvc;
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
        }

        [HttpPost]
        public async Task AddNewCocktail(Cocktail cocktail)
        {
            // clean up
            cocktail.Ingredients = cocktail.Ingredients.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            cocktail.Steps = cocktail.Steps.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

            await _cosmosDbService.AddItemAsync(cocktail);
        }
    }
}
