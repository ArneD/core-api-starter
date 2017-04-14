using MediatR;

namespace Api.Domain.Values.List
{
    public class ListValuesHandler : IRequestHandler<ListValuesRequest, ListValuesResponse>
    {
        public ListValuesResponse Handle(ListValuesRequest message)
        {
            return new ListValuesResponse(new[] { "value1", "value2" });
        }
    }
}
