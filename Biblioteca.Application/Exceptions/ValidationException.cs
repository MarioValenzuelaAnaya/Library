﻿using FluentValidation.Results;

namespace Biblioteca.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException() : base("one or more errors")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

        }


        public IDictionary<string, string[]> Errors { get; }

    }
}
