namespace CrossCutting.Mappers.Contracts
{
    public interface IFromObjectMapper<in TInput, out TOutput>
        where TInput : class
        where TOutput : class
    {
        TOutput MapFrom(TInput input);
    }
}