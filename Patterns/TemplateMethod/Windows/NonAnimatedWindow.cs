namespace Patterns.TemplateMethod.Windows
{
    public class NonAnimatedWindow : WindowBase
    {
        protected override void DoShow(Action callback)
        {
            Console.Out.WriteLine($"[{GetType().Name}] Show Window");
            callback?.Invoke();
        }

        protected override void DoHide(Action callback)
        {
            Console.Out.WriteLine($"[{GetType().Name}] Hide Window");
            callback?.Invoke();
        }
    }
}