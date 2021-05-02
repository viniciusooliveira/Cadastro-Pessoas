namespace CrossCutting.Mappers.Contracts
{
    public interface IToObjectMapper<out TOutput> where TOutput : class
    {
        TOutput MapTo();
    }
}