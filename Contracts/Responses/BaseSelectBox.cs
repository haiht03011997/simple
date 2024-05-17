namespace Contracts.Responses
{
    public class BaseSelectBox<T>
    {
        public T Value { get; set; }
        public required string Label { get; set; }
    }
}
