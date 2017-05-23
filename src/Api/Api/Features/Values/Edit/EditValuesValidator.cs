using FluentValidation;

namespace Api.Features.Values.Edit
{
    public class EditValuesValidator : AbstractValidator<EditValuesRequest>
    {
        public EditValuesValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0).Must(Exist);
            RuleFor(request => request.Value).NotEmpty();
        }

        private bool Exist(int valueId)
        {
            //Check if Value exists

            return valueId <= 5;
        }
    }
}
