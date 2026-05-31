using Patterns.Common;
using Patterns.TemplateMethod.Windows;

namespace Patterns.TemplateMethod
{
    public class TemplateMethodMain : IProgram
    {
        private MainMenuWindow _mainScreen;
        private InGameWindow _inGameScreen;
        private WinWindow _winScreen;
        private ShopWindow _shopScreen;
        private NewSkinPopup _skinPopup;
            
        public void Run(params object[]? args)
        {
            CreateWindows();
            ShowWindows();
        }

        private void CreateWindows()
        {
            _mainScreen = new MainMenuWindow();
            _inGameScreen = new InGameWindow();
            _winScreen = new WinWindow();
            _shopScreen = new ShopWindow();
            _skinPopup = new NewSkinPopup();
        }

        private void ShowWindows()
        {
            _mainScreen.Show();
            _mainScreen.Hide();
            _shopScreen.Show();
            _shopScreen.Hide();
            _inGameScreen.Show();
            _inGameScreen.Hide();
            _winScreen.Show();
            _winScreen.Hide();
            _skinPopup.Show();
            _skinPopup.Hide();
        }
    }
}