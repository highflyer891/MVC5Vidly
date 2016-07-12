using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Mn18YearsIfAMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customers) validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayaAsYouGo)
            {
                return ValidationResult.Success;
            }
            else
            {
                if (customer.BirthDate == null)
                {
                    return  new ValidationResult("Birthdate is required");
                }

                var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

                return (age >= 18)
                    ? ValidationResult.Success
                    : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
            }
        }
    }
}