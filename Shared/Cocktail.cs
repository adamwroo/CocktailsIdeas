using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CocktailsIdeas.Shared
{
    public class Cocktail
    {
        [JsonPropertyName("id")]
        public string id { get; set; }
        public string Name { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
        public List<string> Steps { get; set; } = new List<string>();
    }
}
