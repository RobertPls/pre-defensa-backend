using SharedKernel.Core;
using SharedKernel.Rules;

namespace Domain.ValueObjects
{
    public record NombreValue : ValueObject
    {
        public string FirstName { get; init; }

        public NombreValue(string firstName)
        {
            CheckRule(new StringNotNullOrEmptyRule(firstName));
            if (firstName.Length > 50)
            {
                throw new BussinessRuleValidationException("First name cannot be more than 50 characters");
            }
            FirstName = firstName;
        }

        public static implicit operator string(NombreValue value)
        {
            return value.FirstName;
        }

        public static implicit operator NombreValue(string firstName)
        {
            return new NombreValue(firstName);
        }
    }
}
