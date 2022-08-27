using Todo.me.Model.DataTable;

namespace Todo.me.ViewModel;


[INotifyPropertyChanged]
[QueryProperty(nameof(TodoModel), nameof(TodoModel))]

public partial class TodoDetailsViewModel : BaseViewModel
{

    [ObservableProperty]
    private TodoModel _todoModel;

    public TodoDetailsViewModel()
    {
        TodoModel = new TodoModel();
    }

    [RelayCommand]
    void Save()
    {
        if (TodoModel.Name == null && TodoModel.Description == null)
        {
            Cancel();
        }
        else
        {
            var t = Task.Run(async () =>
            {
                var service = await TodoService.Instance;
                TodoModel.Color = RandomGenerator();
                await service.SaveTodo(TodoModel.Todotable);
            }).
                ContinueInMainThreadWith(async () =>
                {
                    await Shell.Current.GoToAsync("..");
                });
        }
    }
    [RelayCommand]
    void Delete()
    {
        Task.Run(async () =>
        {
            var service = await TodoService.Instance;
            await service.DeleteTodo(TodoModel.Id);

        }).ContinueInMainThreadWith(async () =>
        {
            await Shell.Current.GoToAsync("..");
        });
    }

    [RelayCommand]
    async void Cancel()
    {
        await Shell.Current.GoToAsync("..");
    }
}
