namespace Patterns.TemplateMethod.Windows
{
    public class WinWindow : AnimatedWindow
    {
        protected override void BeforeShow()
        {
            Console.Out.WriteLine("[Win Window] Get levelReward");
            Console.Out.WriteLine("[Win Window] SetupButtons");
        }

        protected override void OnShow()
        {
            Console.Out.WriteLine("[Win Window] Play extra rewards animation");
        }

        protected override void BeforeHide()
        {
            Console.Out.WriteLine("[Win Window] DisableButtons");
        }
    }
}