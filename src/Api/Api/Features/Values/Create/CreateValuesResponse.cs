namespace Api.Features.Values.Create
{
    public class CreateValuesResponse
    {
        public CreateValuesResponse(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public int Id { get; }
        public string Value { get; }
    }
}
