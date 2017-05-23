using MediatR;

namespace Api.Features.Values.Edit
{
    public class EditValuesRequest : IRequest<EditValuesResponse>
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
