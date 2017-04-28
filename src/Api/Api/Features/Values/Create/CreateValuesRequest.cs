using MediatR;

namespace Api.Features.Values.Create
{
    public class CreateValuesRequest : IRequest<CreateValuesResponse>
    {
        public string Value { get; set; }
    }
}
