using MediatR;

namespace Api.Features.Values.Detail
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
