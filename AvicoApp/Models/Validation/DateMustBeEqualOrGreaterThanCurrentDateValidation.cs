using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AvicoApp.Models.Validation
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class DateMustBeEqualOrGreaterThanCurrentDateValidation : ValidationAttribute {

        private const string DefaultErrorMessage = "Date selected {0} must be on or after today";

        public DateMustBeEqualOrGreaterThanCurrentDateValidation()
            : base(DefaultErrorMessage) {
        }

        public override string FormatErrorMessage(string name) {
            return string.Format(DefaultErrorMessage, name);
        }  

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            var dateEntered = (DateTime)value;
            if (dateEntered < DateTime.Today) {
                var message = FormatErrorMessage(dateEntered.ToShortDateString());
                return new ValidationResult(message);
            }
            return null;
        }
    }
}