using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace splc.domain.Validators
{
    public class FutureDateAttribute : ValidationAttribute, IClientValidatable
    {
        private DateTime _date; 
        public FutureDateAttribute() : base("{0} cannot be a future date.")
        {
            //_minDate = Convert.ToDateTime(minDate);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var datetime = Convert.ToDateTime(value);
                _date = datetime;
                if (datetime >= DateTime.Now)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule()
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()), 
                ValidationType = "futuredate"
            };
            rule.ValidationParameters.Add("currentdate", DateTime.Now.ToShortDateString());
            //rule.ValidationParameters.Add("currentdate", DateTime.Now.ToShortDateString());
            yield return rule;

            //var rule = new ModelClientValidationRule {ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())};
            //rule.ValidationParameters.Add("boolrequired", _date);
            //rule.ValidationType = "futuredate";
            //yield return rule;
        }

        //public override bool IsValid(object value)
        //{
        //    var dateTime = Convert.ToDateTime(value);
        //    return false;
        //    //return dateTime <= DateTime.Now;
        //}

        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        //{
        //    yield return new ModelClientValidationRule
        //    {
        //        ErrorMessage = this.ErrorMessage,
        //        ValidationType = "futuredate"
        //    };
        //}

    }

    public class BooleanRequiredAttribute : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            if (value is bool)
                return (bool)value;
            else
                return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata,
            ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "booleanrequired"
            };
        }
    }

}
