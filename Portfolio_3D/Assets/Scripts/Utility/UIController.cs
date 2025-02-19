using UI;

namespace Utility
{
    public class UIController : MonoSingleton<UIController>
    {
        private WindowManager windowManager = new WindowManager();

        public void StartFade(bool fadeIn, float fadeTime = 1f)
        {
            if (windowManager.IsOpenWindow(WindowNameType.UIFadeWindow))
            {
                windowManager.OpenWindow(WindowNameType.UIFadeWindow);
            }

            var window = windowManager.GetWindow<UIFadeWindow>(WindowNameType.UIFadeWindow);
            if (window != null)
            {
                if (fadeIn)
                {
                    window.FadeIn(fadeTime);
                }
                else
                {
                    window.FadeOut(fadeTime);
                }
            }
        }

        public void BackWindow()
        {
            windowManager.BackWindow();
        }
    }
}