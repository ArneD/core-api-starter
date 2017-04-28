﻿using System;
using MediatR;

namespace Api.Domain.Values.Create
{
    public class CreateValuesHandler : IRequestHandler<CreateValuesRequest, CreateValuesResponse>
    {
        public CreateValuesResponse Handle(CreateValuesRequest message)
        {
            return new CreateValuesResponse(new Random().Next(100), message.Value);
        }
    }
}
