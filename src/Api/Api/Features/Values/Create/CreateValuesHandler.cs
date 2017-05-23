using System;
using MediatR;

namespace Api.Features.Values.Create
{
    public class CreateValuesHandler : IRequestHandler<CreateValuesRequest, CreateValuesResponse>
    {
        public CreateValuesResponse Handle(CreateValuesRequest message)
        {
            //Create domain object

            return new CreateValuesResponse(new Random().Next(100), message.Value);
        }
    }
}
