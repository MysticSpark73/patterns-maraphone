namespace Patterns.TemplateMethod.Windows
{
    public class ShopWindow : AnimatedWindow
    {
        protected override void BeforeShow()
        {
            Console.Out.WriteLine("[ShopWindow] Get ShopData");
            Console.Out.WriteLine("[ShopWindow] Setup buttons");
        }

        protected override void OnShow()
        {
            Console.Out.WriteLine("[ShopWindow] Display shop items");
        }

        protected override void BeforeHide()
        {
            Console.Out.WriteLine("[ShopWindow] Disable buttons");
        }
    }
}