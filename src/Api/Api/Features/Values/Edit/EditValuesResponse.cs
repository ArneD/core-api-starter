namespace Api.Features.Values.Edit
{
    public class EditValuesResponse
    {
        public int Id { get; }
        public string Value { get; }

        public EditValuesResponse(int id, string value)
        {
            Id = id;
            Value = value;
        }
    }
}