using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class OrderItemDto : IValidatableObject
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime ModifiedOn { get; set; }

        public int OrderId { get; set; }
        public OrderDto Order { get; set; }
        public int ItemId { get; set; }
        public ItemDto Item { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //TO DO
            if (Quantity == 0)
                yield return new ValidationResult("Quantity must be positive number");
        }
    }
}
