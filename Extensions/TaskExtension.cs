namespace Todo.me.Extensions;
public static class TaskExtension
{
    public static Task ContinueInMainThreadWith<T>(this Task<T> task, Action<T> action)
    {
        return task.ContinueWith(async (t) =>
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                action.Invoke(t.Result);
            });

        },
        TaskScheduler.FromCurrentSynchronizationContext()
        );
    }

    public static Task ContinueInMainThreadWith(this Task task, Action action)
    {
        return task.ContinueWith(async (t) =>
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                action.Invoke();
            });
        },
        TaskScheduler.FromCurrentSynchronizationContext()
        );
    }
}
