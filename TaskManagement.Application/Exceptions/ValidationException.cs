using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace TaskManagement.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors;
        public ValidationException() : base("One or more validation failures  have occured.")
        {
            Errors = new List<string>();
        }
        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
