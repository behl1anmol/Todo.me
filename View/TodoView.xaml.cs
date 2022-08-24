namespace Todo.me.View;

public partial class TodoView : ContentPage
{
	public TodoView(TodoViewModel _viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as TodoViewModel).Refresh();
    }
}