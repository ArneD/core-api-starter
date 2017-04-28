namespace Api.Features.Values.Detail
{
    public class DetailValuesResponse
    {
        public DetailValuesResponse(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
