namespace CovfefeBucks.Core.Interfaces;

public interface IMapper<in TInput, out TOutput>
{
    public TOutput Map(TInput src);
    public IEnumerable<TOutput> MapEach(IEnumerable<TInput> src);
}