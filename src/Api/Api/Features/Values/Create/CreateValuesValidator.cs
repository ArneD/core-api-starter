using FluentValidation;

namespace Api.Features.Values.Create
{
    public class CreateValuesValidator : AbstractValidator<CreateValuesRequest>
    {
        public CreateValuesValidator()
        {
            RuleFor(request => request.Value).NotEmpty();
        }
    }
}
