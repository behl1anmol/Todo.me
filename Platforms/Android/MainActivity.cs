using Android.App;
using Android.Content.PM;
using Android.OS;

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
}
