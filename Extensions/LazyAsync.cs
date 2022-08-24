namespace Todo.me.Extensions;
public class LazyAsync<T>
{
    readonly Lazy<Task<T>> instance;
    public LazyAsync(Func<T> factory)
    {
        instance = new Lazy<Task<T>>(() => Task.Run(factory));
    }

    public LazyAsync(Func<Task<T>> factory)
    {
        instance = new Lazy<Task<T>>(() => Task.Run(factory));
    }

    public TaskAwaiter<T> GetAwaiter()
    {
        return instance.Value.GetAwaiter();
    }
}
