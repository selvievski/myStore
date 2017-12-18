using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class ItemDto : IValidatableObject
    {
        public ItemDto()
        {
            OrderItems = new List<OrderItemDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public int NumberOfUnits { get; set; }
        public DateTime ModifiedOn { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //TO DO
            if (Name.Length == 0)
                yield return new ValidationResult("The Name must not be empty");
        }
    }
}
