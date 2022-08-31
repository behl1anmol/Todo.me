namespace Todo.me.ViewModel;

[INotifyPropertyChanged]
public partial class MainPageViewModel :BaseViewModel
{

    public MainPageViewModel()
    {
    
    }

    [RelayCommand]
    async void GotoTodoView()
    {
        if (IsBusy) return;
        IsBusy = true;
        await Shell.Current.GoToAsync("MainToTodoView");
        IsBusy = false;
    }
}
