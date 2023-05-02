namespace AdAstra
{
    public interface INasaClient<in TIn, out TOut>
    {
        TOut GetAsync(TIn input);
    }
}
