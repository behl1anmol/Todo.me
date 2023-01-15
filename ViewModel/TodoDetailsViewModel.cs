using Microsoft.Maui.ApplicationModel;
using Todo.me.Model.DataTable;
using Todo.me.Repository;

namespace Todo.me.ViewModel;


[INotifyPropertyChanged]
[QueryProperty(nameof(TodoModel), nameof(TodoModel))]

public partial class TodoDetailsViewModel : BaseViewModel
{
    public AppThemeService _appTheme;

    private readonly ITodoRepository _todoRepository;

    [ObservableProperty]
    private TodoModel _todoModel;

    public TodoDetailsViewModel(AppThemeService appTheme, ITodoRepository _todoRepository)
    {
        TodoModel = new TodoModel();
        this._todoRepository = _todoRepository;
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
                //var service = await TodoService.Instance;
                TodoModel.Color = RandomGenerator();
                await _todoRepository.SaveItem(TodoModel.Todotable);
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
            //var service = await TodoService.Instance;
            await _todoRepository.DeleteItem(TodoModel.Id);

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
