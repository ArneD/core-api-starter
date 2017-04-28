using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Api.Domain.Values.List
{
    public class ListValuesResponse : Collection<ListValuesResponseItem>
    {
        public ListValuesResponse(IList<ListValuesResponseItem> values)
            : base (values)
        { }
    }

    public class ListValuesResponseItem
    {
        public ListValuesResponseItem(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public int Id { get; }
        public string Value { get; }
    }
}
