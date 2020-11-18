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
                value = 0;

            var otherProperty = validationContext.ObjectType.GetProperty(OtherProperty);
            var otherPropertyValue = (string)otherProperty.GetValue(validationContext.ObjectInstance, null);

            /*if (properties.Length == 0 && (Int32)value == 0)
            {
                return new ValidationResult(String.Empty);
            }
            var otherValue = properties.GetValue(0);

                // at this stage you have "value" and "otherValue" pointing
                // to the value of the property on which this attribute
                // is applied and the value of the other property respectively
                // => you could do some checks
                if (!object.Equals(value, otherValue))
                {
                    // here we are verifying whether the 2 values are equal
                    // but you could do any custom validation you like
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }*/
                return null;
            }
            

        
    }
}
