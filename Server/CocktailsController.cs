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
        [HttpGet]
        public async Task<ActionResult<List<Cocktail>>> GetCocktails()
        {
            var dummyCocktailList = new List<Cocktail>
            {
                new Cocktail {Id = "1", Name = "Cuba Libre"},
                new Cocktail {Id = "2", Name = "Mojito"}
            };

            return await Task.FromResult(dummyCocktailList);
        }
    }
}
