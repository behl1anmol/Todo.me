namespace Todo.me.ViewModel;

[INotifyPropertyChanged]
public partial class TodoViewModel :BaseViewModel
{

    public ObservableCollection<TodoModel> TodoModels
    {
        private set; get;
    } = new ObservableCollection<TodoModel>();


    public TodoViewModel()
    {

    }

    [RelayCommand]
    async void TodoTapped(TodoModel todoModel)
    {
        if (IsBusy) return;
        IsBusy = true;
        await Shell.Current.GoToAsync(nameof(TodoDetailsView), true,
            new Dictionary<string, object>()
            {
                ["TodoModel"] = todoModel,
            });
        IsBusy = false;
    }

    [RelayCommand]
    void IsCompleteTapped(TodoModel todoModel)
    {
        Task.Run(async () =>
        {
            var service = await TodoService.Instance;
            await service.SaveTodo(todoModel.Todotable);
        });
    }
    [RelayCommand]
    async void AddTapped()
    {
        if (IsBusy) return;
        IsBusy = true;
        await Shell.Current.GoToAsync(nameof(TodoDetailsView));
        IsBusy = false;
    }

    [RelayCommand]
    async void GotoMainPage()
    {
        if (IsBusy) return;
        IsBusy = true;
        await Shell.Current.GoToAsync("..");
        IsBusy = false;
    }

    internal void Refresh()
    {
        if (IsBusy)
        {
            return;
        }
        IsBusy = true;

        Task.Run<List<TodoTable>>(async () =>
        {
            var service = await TodoService.Instance;
            var tasks = await service.GetTodos();
            tasks.Sort((t1, t2) =>
            {
                if (t1.IsComplete == t2.IsComplete)
                {
                    return t1.Id < t2.Id ? -1 : 1;
                }
                else if (t1.IsComplete)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            });
            return tasks;
        }).
        ContinueInMainThreadWith((taskTables) =>
        {
            TodoModels.Clear();
            if (taskTables != null && taskTables.Count > 0)
            {
                taskTables.ForEach((t) => { TodoModels.Add(new TodoModel(t)); });
            }

            IsBusy = false;
        });



    }




}
