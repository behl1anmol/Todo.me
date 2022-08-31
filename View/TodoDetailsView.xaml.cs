namespace Todo.me.View;

public partial class TodoDetailsView : ContentPage
{
	public TodoDetailsView(TodoDetailsViewModel _viewModel)
	{
		InitializeComponent();
        var hash = _viewModel.GetHashCode();
        BindingContext = _viewModel;
    }
}