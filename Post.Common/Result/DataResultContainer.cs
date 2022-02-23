namespace Post.Common.Result
{
    public class ResultContainer<T> : ResultContainer
    {
        public T Data { get; set; }
    }
}