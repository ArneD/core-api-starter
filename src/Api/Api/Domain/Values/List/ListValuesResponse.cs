using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Api.Domain.Values.List
{
    public class ListValuesResponse : Collection<string>
    {
        public ListValuesResponse(IList<string> values)
            :base (values)
        { }
    }
}
