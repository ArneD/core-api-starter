using System.Collections.Generic;

namespace Api.Features.Values.List
{
    public class ListValuesResponse
    {
        public ListValuesResponse(IList<ListValuesResponseItem> values, IEnumerable<Link> links)
        {
            Values = values;
            Links = links;
        }

        public IList<ListValuesResponseItem> Values { get; }
        public IEnumerable<Link> Links { get; }
    }

    public class ListValuesResponseItem
    {
        public ListValuesResponseItem(int id, string value, IEnumerable<Link> links)
        {
            Id = id;
            Value = value;
            Links = links;
        }

        public int Id { get; }
        public string Value { get; }
        public IEnumerable<Link> Links { get; }
    }
}

