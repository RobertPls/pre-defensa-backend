using SharedKernel.Core;
using SharedKernel.Rules;

namespace Domain.ValueObjects
{
    public record ApellidoValue : ValueObject
    {
        public string LastName { get; init; }

        public ApellidoValue(string lastName)
        {
            CheckRule(new StringNotNullOrEmptyRule(lastName));
            if (lastName.Length > 100)
            {
                throw new BussinessRuleValidationException("Last name cannot be more than 100 characters");
            }
            LastName = lastName;
        }

        public static implicit operator string(ApellidoValue value)
        {
            return value.LastName;
        }

        public static implicit operator ApellidoValue(string lastName)
        {
            return new ApellidoValue(lastName);
        }
    }
}
