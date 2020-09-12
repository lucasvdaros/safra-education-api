using System;
using FluentValidation.Results;

namespace SafraEducacional.Domain.Validator
{
    public abstract class BusinessValidator
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected BusinessValidator()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}