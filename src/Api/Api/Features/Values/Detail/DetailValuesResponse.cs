using System.Collections.Generic;

namespace Api.Features.Values.Detail
{
    public class DetailValuesResponse : BaseHateosResponse
    {
        public DetailValuesResponse(string value, IEnumerable<Link> links)
            : base(links)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
