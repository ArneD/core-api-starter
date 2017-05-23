using System.Collections.Generic;
using Api.Features.Values.Delete;
using Api.Features.Values.Detail;
using Api.Features.Values.Edit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Features.Values.List
{
    public class ListValuesHandler : IRequestHandler<ListValuesRequest, ListValuesResponse>
    {
        private readonly IUrlHelper _urlHelper;

        public ListValuesHandler(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public ListValuesResponse Handle(ListValuesRequest message)
        {
            return new ListValuesResponse(new []
            {
                new ListValuesResponseItem(1, "value1", CreateValueLinks(1)),
                new ListValuesResponseItem(2, "value2", CreateValueLinks(2)),
                new ListValuesResponseItem(3, "value3", CreateValueLinks(3)),
                new ListValuesResponseItem(4, "value4", CreateValueLinks(4)),
                new ListValuesResponseItem(5, "value5", CreateValueLinks(5)),
            }, CreateLinks());
        }

        private IEnumerable<Link> CreateLinks()
        {
            return new []
            {
                new Link
                {
                    Type = "POST",
                    Rel = "self",
                    Href = _urlHelper.Link(ValuesController.PostRouteName, null)
                },
            };
        }

        private IEnumerable<Link> CreateValueLinks(int id)
        {
            var links = new[]
            {
                new Link
                {
                    Type = "GET",
                    Rel = "self",
                    Href = _urlHelper.Link(ValuesController.GetByIdRouteName, new DetailValuesRequest{ Id = id})
                },
                new Link
                {
                    Type = "PUT",
                    Rel = "self",
                    Href = _urlHelper.Link(ValuesController.PutRouteName, new EditValuesRequest{ Id = id})
                },
                new Link
                {
                    Type = "DELETE",
                    Rel = "self",
                    Href = _urlHelper.Link(ValuesController.DeleteRouteName, new DeleteValuesRequest{ Id = id})
                },
            };
            return links;
        }
    }
}
