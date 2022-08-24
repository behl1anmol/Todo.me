namespace Todo.me;

public partial class App : Application
{
	public App(AppShell shell)
	{
		InitializeComponent();

		MainPage = shell;

        Routing.RegisterRoute(nameof(TodoDetailsView), typeof(TodoDetailsView));
        Routing.RegisterRoute(nameof(SprintDetailsView), typeof(SprintDetailsView));

    }
}
