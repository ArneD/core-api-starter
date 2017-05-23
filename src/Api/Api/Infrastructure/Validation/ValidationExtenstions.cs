using FluentValidation;
using FluentValidation.Results;

namespace Api.Infrastructure.Validation
{
    public static class ValidationExtensions
    {
        public static bool HasValidationErrorCode(this ValidationFailure failure, ValidationErrorCode errorCode)
        {
            return failure.CustomState != null && failure.CustomState.Equals(errorCode);
        }

        public static IRuleBuilderOptions<T, TProperty> WithErrorCode<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rulebuilder, ValidationErrorCode errorCode)
        {
            return rulebuilder.WithState(state => errorCode);
        }
    }
}
