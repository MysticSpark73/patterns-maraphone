namespace Patterns.TemplateMethod.Windows
{
    public class InGameWindow : NonAnimatedWindow
    {
        protected override void BeforeShow()
        {
            Console.Out.WriteLine("[InGameWindow] Setup score");
            Console.Out.WriteLine("[InGameWindow] Setup HP bar");
            Console.Out.WriteLine("[InGameWindow] Subscribe to in-game events");
        }

        protected override void BeforeHide()
        {
            Console.Out.WriteLine("[InGameWindow] Unsubscribe from in-game events");
        }
    }
}