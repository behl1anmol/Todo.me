namespace Todo.me.View;

public partial class TodoDetailsView : ContentPage
{
	public TodoDetailsView(TodoDetailsViewModel _viewModel)
	{
		InitializeComponent();
        var hash = _viewModel.GetHashCode();
        BindingContext = _viewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as TodoDetailsViewModel).Refresh();
    }
}