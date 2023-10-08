using Customers_API.Models;
using FluentValidation;

namespace Customers_API
{
    /// <summary>
    /// Validator for <see cref="Customer"/>
    /// </summary>
    public class CustomerValidator : AbstractValidator<Customer>
    {
        /// <summary>
        /// Create
        /// </summary>
        public const string Create = "CreateRuleSet";

        /// <summary>
        /// Maximum amount of characters allowed
        /// </summary>
        public const int MaximumCharacters = 100;

        /// <summary>
        /// Create rulesets
        /// </summary>
        public CustomerValidator()
        {
            RuleSet(Create, () =>
            {
                // "ERROR_CODE_FIELDS" to be translated in the UI to the local language used by user

                RuleFor(c => c.FirstName)
                    .NotEmpty()
                    .When(customer => customer.FirstName != null)
                    .OverridePropertyName("FirstName")
                    .WithErrorCode("MUST_NOT_BE_EMPTY");
                RuleFor(c => c.FirstName)
                    .MaximumLength(MaximumCharacters)
                    .When(customer => !string.IsNullOrEmpty(customer.FirstName))
                    .OverridePropertyName("FirstName")
                    .WithErrorCode("MUST_NOT_EXCEED_CHARACTER_LIMIT");
                RuleFor(c => c.LastName)
                    .NotEmpty()
                    .When(customer => customer.LastName != null)
                    .OverridePropertyName("LastName")
                    .WithErrorCode("MUST_NOT_BE_EMPTY");
                RuleFor(c => c.LastName)
                    .MaximumLength(MaximumCharacters)
                    .When(customer => !string.IsNullOrEmpty(customer.LastName))
                    .OverridePropertyName("LastName")
                    .WithErrorCode("MUST_NOT_EXCEED_CHARACTER_LIMIT");
                RuleFor(c => c.BirthDate)
                    .LessThan(DateTime.Today.Date)
                    .OverridePropertyName("BirthDate")
                    .WithErrorCode("MUST_BE_IN_PAST");
                RuleFor(c => c.AnnualIncome)
                    .GreaterThan(0)
                    .OverridePropertyName("AnnualIncome")
                    .WithErrorCode("MUST_BE_BIGGER_THAN_0");
            });
        }
    }
}
