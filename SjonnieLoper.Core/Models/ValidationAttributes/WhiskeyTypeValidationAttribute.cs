using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace SjonnieLoper.Core.Models
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public class WhiskeyTypeValidationAttribute : ValidationAttribute
    {
            public string OtherProperty { get; set; }
            /*public WhiskeyTypeValidationAttribute(string other)
            {
                _other = other;
            }*/

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
            if (value == null)
                value = String.Empty;

            var otherProperty = validationContext.ObjectType.GetProperty(OtherProperty);
            int otherPropertyValue = Int32.Parse((string)otherProperty.GetValue(validationContext.ObjectInstance, null));

            if (otherPropertyValue == 0 && String.Equals((string)value, String.Empty))
            {
                return new ValidationResult(String.Empty);
            } 
            else if (otherPropertyValue != 0 && !String.Equals((string)value, String.Empty))
            {
                return new ValidationResult("Please select only one type");
            }
            return null;
            }
            

        
    }
}
