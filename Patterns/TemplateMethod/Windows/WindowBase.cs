namespace Patterns.TemplateMethod.Windows
{
    public abstract class WindowBase
    {
        public void Show()
        {
            Console.Out.WriteLine($"\n========= Show {GetType().Name} =========");
            BeforeShow();
            DoShow(OnShow);
        }

        public void Hide()
        {
            Console.Out.WriteLine($"\n========= Hide {GetType().Name} =========");
            BeforeHide();
            DoHide(OnHide);
        }

        protected virtual void BeforeShow(){}
        
        protected virtual void OnShow(){}
        
        protected virtual void DoShow(Action callback){}
        
        protected virtual void BeforeHide(){}

        protected virtual void DoHide(Action callback) {}
        
        protected virtual void OnHide(){}
    }
}