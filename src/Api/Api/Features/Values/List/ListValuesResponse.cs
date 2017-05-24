namespace Api.Features.Values.List
{
    using System.Collections.Generic;

    public class ListValuesResponse : BaseHateosResponse
    {
        public ListValuesResponse(IList<ListValuesResponseItem> values, IEnumerable<Link> links)
            : base(links)
        {
            Values = values;
        }

        public IList<ListValuesResponseItem> Values { get; }
    }

    public class ListValuesResponseItem : BaseHateosResponse
    {
        public ListValuesResponseItem(int id, string value, IEnumerable<Link> links)
            : base(links)
        {
            Id = id;
            Value = value;
        }

        public int Id { get; }
        public string Value { get; }
    }
}