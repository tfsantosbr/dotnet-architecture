using AutoMapper;

namespace Project.API.Base.MapperAdapters
{
    public class AutoMapperAdapter : IMapperAdapter
    {
        private readonly IMapper _mapper;

        public AutoMapperAdapter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TTarget Adapt<TSource, TTarget>(TSource source)
        {
            return _mapper.Map<TTarget>(source);
        }
    }
}