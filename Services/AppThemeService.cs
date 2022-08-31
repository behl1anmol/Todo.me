namespace Todo.me.Services;
public class AppThemeService
{
#if __ANDROID__
    public IThemeEnvironment e;
    public AppThemeService(IThemeEnvironment _e)
    {
        e = _e;
    }
    public void SetAppTheme()
    {

        var nav = App.Current.MainPage as NavigationPage;
        if (App.Current.RequestedTheme == AppTheme.Dark)
        {
            e?.SetStatusBarColor(Android.Graphics.Color.Rgb(36, 37, 37), false);
            if (nav != null)
            {
                nav.BarBackgroundColor = Color.Parse("Black");
                nav.BarTextColor = Color.Parse("White");
            }
        }
        else
        {
            e?.SetStatusBarColor(Android.Graphics.Color.White, true);
            if (nav != null)
            {
                nav.BarBackgroundColor = Color.Parse("White");
                nav.BarTextColor = Color.Parse("Black");
            }
        }
    }
    public void SetStaticStatusBarColor(Android.Graphics.Color Color)
    {
        e?.SetStatusBarColor(Color, true);
    }
#endif
}
