﻿namespace Todo.me;

public partial class App : Application
{
    AppThemeService _appTheme;
	public App(AppShell shell, AppThemeService appTheme)
    {
        InitializeComponent();

        MainPage = shell;

        Routing.RegisterRoute("MainToTodoView", typeof(TodoView));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(TodoView), typeof(TodoView));
        Routing.RegisterRoute(nameof(TodoDetailsView), typeof(TodoDetailsView));
        Routing.RegisterRoute(nameof(SprintDetailsView), typeof(SprintDetailsView));
        _appTheme = appTheme;
    }

    protected override void OnStart()
    {
        OnResume();
    }

    protected override void OnSleep()
    {
        _appTheme.SetAppTheme();
        RequestedThemeChanged -= App_RequestedThemeChanged;
    }

    protected override void OnResume()
    {
        _appTheme.SetAppTheme();
        RequestedThemeChanged += App_RequestedThemeChanged;
    }

    private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            _appTheme.SetAppTheme();
        });
    }
}
