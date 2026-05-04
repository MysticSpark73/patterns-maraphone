namespace Patterns.State.Extensions
{
    public static class TasksExtension
    {
        public static void RunSync(this Task task)
        {
            Task.Run(() => task).GetAwaiter().GetResult();
        }
        
        public static void Forget(this Task task)
        {
            if (!task.IsCompleted || task.IsFaulted)
            {
                _ = Observe(task);
            }

            static async Task Observe(Task t)
            {
                try
                {
                    await t.ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    // expected → ignore
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}