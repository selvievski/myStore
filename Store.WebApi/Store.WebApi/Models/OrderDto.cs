using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class OrderDto : IValidatableObject
    {
        public OrderDto()
        {
            Customer = new CustomerDto();
            OrderItems = new List<OrderItemDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Active { get; set; }
        public DateTime ModifiedOn { get; set; }


        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //TO DO
            if (Name.Length == 0)
                yield return new ValidationResult("The Name must not be empty");
        }
    }
}
