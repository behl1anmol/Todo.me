namespace Todo.me.View;

public partial class SprintView : ContentPage
{
	public SprintView(SprintViewModel _sprintViewModel)
	{
		InitializeComponent();
        BindingContext = _sprintViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as SprintViewModel).Refresh();
    }
}