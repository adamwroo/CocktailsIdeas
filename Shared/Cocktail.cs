using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CocktailsIdeas.Shared
{
    public class Cocktail
    {
        [JsonPropertyName("id")]
        public string id { get; set; }
        [Required(ErrorMessage = "Please provide a cocktail's name")]
        [MinLength(5, ErrorMessage = "The name has to have at least 5 characters")]
        public string Name { get; set; }
        [Required]
        [MinCollectionCount(2, ErrorMessage = "Add at least one ingredient")] // todo: this should be 1
        public List<string> Ingredients { get; set; } = new List<string>();
        [Required]
        [MinCollectionCount(2, ErrorMessage = "Add at least one step")] // todo: this should be 1
        public List<string> Steps { get; set; } = new List<string>();
    }
}
