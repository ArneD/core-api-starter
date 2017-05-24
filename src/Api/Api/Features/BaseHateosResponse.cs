namespace Api.Features
{
    using System.Collections.Generic;

    public class BaseHateosResponse
    {
        public BaseHateosResponse(IEnumerable<Link> links)
        {
            Links = links;
        }

        public IEnumerable<Link> Links { get; }
    }
}
