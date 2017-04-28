using MediatR;

namespace Api.Features.Values.Detail
{
    public class DetailValuesRequest : IRequest<DetailValuesResponse>
    {
        public int Id { get; set; }
    }
}
