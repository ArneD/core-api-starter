using MediatR;

namespace Api.Domain.Values.Detail
{
    public class DetailValuesHandler : IRequestHandler<DetailValuesRequest, DetailValuesResponse>
    {
        public DetailValuesResponse Handle(DetailValuesRequest message)
        {
            if (message.Id > 5)
                return null;
            return new DetailValuesResponse($"value{message.Id}");
        }
    }
}
