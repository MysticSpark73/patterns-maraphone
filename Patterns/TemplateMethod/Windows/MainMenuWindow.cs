namespace Patterns.TemplateMethod.Windows
{
    public class MainMenuWindow : AnimatedWindow
    {
        protected override void BeforeShow()
        {
            Console.Out.WriteLine("[MainMenuWindow] SetupButtons");
            Console.Out.WriteLine("[MainMenuWindow] Get currency data");
        }

        protected override void OnShow()
        {
            Console.Out.WriteLine("[MainMenuWindow] Start currency animation");
        }

        protected override void BeforeHide()
        {
            Console.Out.WriteLine("[MainMenuWindow] Disable buttons");
        }
    }
}