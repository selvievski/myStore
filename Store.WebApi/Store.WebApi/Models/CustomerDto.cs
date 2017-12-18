using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class CustomerDto : IValidatableObject
    {
        public CustomerDto()
        {
            Orders = new List<OrderDto>();
        }

        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime ModifiedOn { get; set; }
        public List<OrderDto> Orders { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //TO DO

            if (CustomerId != 0)
                if (Username.Length == 0)
                    yield return new ValidationResult("The Username must not be empty");
        }
    }
}
