namespace Api.Features.Values.Detail
{
    using System.Collections.Generic;

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