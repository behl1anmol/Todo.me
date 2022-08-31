namespace Todo.me.Contracts;
public interface IThemeEnvironment
{
#if __ANDROID__
    void SetStatusBarColor(Android.Graphics.Color color, bool darkStatusBar);
#endif
}
