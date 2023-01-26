using Todo.me.ViewModel;

namespace Todo.me.View;

public partial class SprintDetailsView : ContentPage
{
	public SprintDetailsView(SprintDetailsViewModel sprintDetailsViewModel)
	{
		InitializeComponent();
        BindingContext = sprintDetailsViewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as SprintDetailsViewModel).Refresh();
    }
}