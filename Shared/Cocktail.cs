using System.Text.Json.Serialization;

namespace CocktailsIdeas.Shared
{
    public class Cocktail
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
