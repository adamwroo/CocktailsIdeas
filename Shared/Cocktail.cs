using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CocktailsIdeas.Shared.CustomValidationAttributes;

namespace CocktailsIdeas.Shared
{
    public class Cocktail
    {
        [JsonPropertyName("id")]
        public string id { get; set; }
        [Required(ErrorMessage = "Provide a name")]
        [MinLength(3, ErrorMessage = "Name has lass than 3 characters")]
        public string Name { get; set; }
        [Required]
        [MinNonEmptyCollectionCount(1, ErrorMessage = "Add at least one ingredient")]
        public List<string> Ingredients { get; set; } = new List<string>();
        [Required]
        [MinNonEmptyCollectionCount(1, ErrorMessage = "Add at least one step")]
        public List<string> Steps { get; set; } = new List<string>();
    }
}
