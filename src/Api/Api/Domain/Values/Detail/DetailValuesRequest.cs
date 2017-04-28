using MediatR;

namespace Api.Domain.Values.Detail
{
    public class DetailValuesRequest : IRequest<DetailValuesResponse>
    {
        public int Id { get; set; }
    }
}
