using MediatR;

namespace Api.Features.Values.Edit
{
    public class EditValuesHandler : IRequestHandler<EditValuesRequest, EditValuesResponse>
    {
        public EditValuesResponse Handle(EditValuesRequest message)
        {
            // Update object in domain

            return new EditValuesResponse(message.Id, message.Value);
        }
    }
}
