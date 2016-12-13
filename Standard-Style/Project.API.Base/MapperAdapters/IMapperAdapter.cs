namespace Project.API.Base.MapperAdapters
{
    public interface IMapperAdapter
    {
        TTarget Adapt<TSource, TTarget>(TSource source);
    }
}