using MediatR;

namespace Api.Features.Values.List
{
    public class ListValuesHandler : IRequestHandler<ListValuesRequest, ListValuesResponse>
    {
        public ListValuesResponse Handle(ListValuesRequest message)
        {
            return new ListValuesResponse(new []
            {
                new ListValuesResponseItem(1, "value1"),
                new ListValuesResponseItem(2, "value2"),
                new ListValuesResponseItem(3, "value3"),
                new ListValuesResponseItem(4, "value4"),
                new ListValuesResponseItem(5, "value5"),
            });
        }
    }
}
