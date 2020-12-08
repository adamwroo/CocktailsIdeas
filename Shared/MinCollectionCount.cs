using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CocktailsIdeas.Shared
{
    public class MinCollectionCount : ValidationAttribute
    {
        public int Count { get; set; }

        public MinCollectionCount(int count)
        {
            Count = count;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int count;
            // Automatically pass if value is null. RequiredAttribute should be used to assert a value is not null.
            if (value == null)
            {
                return null;
            }

            if (value is IEnumerable<object> collection)
            {
                count = collection.Count();
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
