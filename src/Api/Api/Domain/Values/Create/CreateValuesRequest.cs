using MediatR;

namespace Api.Domain.Values.Create
{
    public class CreateValuesRequest : IRequest<CreateValuesResponse>
    {
        public string Value { get; set; }
    }
}
