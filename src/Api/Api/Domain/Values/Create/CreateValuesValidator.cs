using FluentValidation;

namespace Api.Domain.Values.Create
{
    public class CreateValuesValidator : AbstractValidator<CreateValuesRequest>
    {
        public CreateValuesValidator()
        {
            RuleFor(request => request.Value).NotEmpty();
        }
    }
}
