using MediatR;

namespace Api.Features.Values.Delete
{
    public class DeleteValuesRequest : IRequest
    {
        public int Id { get; set; }
    }
}
