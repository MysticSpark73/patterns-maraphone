namespace Patterns.TemplateMethod.Windows
{
    public class AnimatedWindow : WindowBase
    {
        protected override void DoShow(Action callback)
        {
            Console.Out.WriteLine($"[{GetType().Name}] Play show animation");
            Console.Out.WriteLine($"[{GetType().Name}] Show window");
            callback?.Invoke();
        }

        protected override void DoHide(Action callback)
        {
            Console.Out.WriteLine($"[{GetType().Name}] Play Hide animation");
            Console.Out.WriteLine($"[{GetType().Name}] Hide Window");
            callback?.Invoke();
        }
    }
}