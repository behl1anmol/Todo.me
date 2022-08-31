using CommunityToolkit.Maui;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace Todo.me;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit()
        .UseSkiaSharp();

        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<TodoViewModel>();
        builder.Services.AddSingleton<SprintViewModel>();
        builder.Services.AddSingleton<MainPageViewModel>();

#if __ANDROID__
        builder.Services.AddSingleton<IThemeEnvironment, Todo.me.ThemeEnvironment>();
#endif
        builder.Services.AddSingleton<AppThemeService>();

        builder.Services.AddSingleton<TodoView>();
        builder.Services.AddSingleton<SprintView>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddTransient<TodoDetailsViewModel>();
        builder.Services.AddTransient<SprintDetailsViewModel>();
        builder.Services.AddTransient<TodoDetailsView>();
        builder.Services.AddTransient<SprintDetailsView>();
       


        return builder.Build();
    }
}