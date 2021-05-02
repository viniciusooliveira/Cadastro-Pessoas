namespace CrossCutting.Mappers.Contracts
{
    public interface IObjectMapper<TInput, out TOutput> : 
        IFromObjectMapper<TInput, TOutput>,
        IToObjectMapper<TInput>
        where TInput : class
        where TOutput : class
    {
    }
}