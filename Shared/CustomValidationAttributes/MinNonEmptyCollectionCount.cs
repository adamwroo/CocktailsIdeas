using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CocktailsIdeas.Shared.CustomValidationAttributes
{
    public class MinNonEmptyCollectionCount : ValidationAttribute
    {
        public int Count { get; set; }

        public MinNonEmptyCollectionCount(int count)
        {
            Count = count;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Automatically pass if value is null. RequiredAttribute should be used to assert a value is not null.
            if (value == null)
            {
                return null;
            }

            int count;
            if (value is IEnumerable<string> collection)
            {
                count = collection.Count(x => !string.IsNullOrWhiteSpace(x));
            }
            else
            {
                throw new InvalidCastException();
            }

            if (count < Count)
            {
                return new ValidationResult(ErrorMessage ?? $"Number of elements less than {Count}",
                    new[] {validationContext.MemberName});
            }

            return null;
        }
    }
}
