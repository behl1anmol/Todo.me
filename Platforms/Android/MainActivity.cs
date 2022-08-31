using Android.App;
using Android.Content.PM;
using Android.OS;
using DependencyAttribute = Microsoft.Maui.Controls.DependencyAttribute;

[assembly: Dependency(typeof(Todo.me.ThemeEnvironment))]
namespace Todo.me;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{

    //protected override void OnCreate(Bundle savedInstanceState)
    //{
    //    try
    //    {
    //        base.OnCreate(savedInstanceState);
    //    }
    //    catch(Exception ex)
    //    {
    //        var client = new HttpClient();
    //        client.PostAsync("eoiilmgmqsjckkc.m.pipedream.net", new StringContent(ex.ToString()));
    //    }
    //}
    protected override void OnCreate(Bundle savedInstanceState)
    {
        //...
        base.SetTheme(Resource.Style.Maui_SplashTheme);
        base.OnCreate(savedInstanceState);

        //...
    }
}

public class ThemeEnvironment : IThemeEnvironment
{
    public void SetStatusBarColor(Android.Graphics.Color color, bool darkStatusBar)
    {
        if (Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop)
            return;
        var activity = Platform.CurrentActivity;
        var window = activity.Window;

        window.AddFlags(Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);
        window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);
        window.SetStatusBarColor(color);

        if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
        {
            var _flag = (Android.Views.StatusBarVisibility)Android.Views.SystemUiFlags.LightStatusBar;
            window.DecorView.SystemUiVisibility = darkStatusBar ? _flag : 0;
        }


    }
}
