namespace Patterns.TemplateMethod.Windows
{
    public class NewSkinPopup : NonAnimatedWindow
    {
        protected override void BeforeShow()
        {
            Console.Out.WriteLine("[NewSkinPopup] Get SkinData");
        }

        protected override void OnHide()
        {
            Console.Out.WriteLine("[NewSkinPopup] Unlock new skin");
        }
    }
}