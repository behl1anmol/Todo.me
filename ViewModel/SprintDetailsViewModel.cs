using Todo.me.Repository;

namespace Todo.me.ViewModel;

[INotifyPropertyChanged]
[QueryProperty(nameof(SprintTodoTableItems),nameof(SprintTodoTableItems))]
[QueryProperty(nameof(SprintID), nameof(SprintID))]
public partial class SprintDetailsViewModel : BaseViewModel
{
    private readonly ITodoRepository _todoRepository;
    private readonly ISprintRepository _sprintRepository;

    public List<TodoTable> SprintTodoTableItems 
    {
        get;
        set;
    }

    [ObservableProperty]
    public ObservableCollection<TodoModel> _sprintTodoItems;

    public int SprintID
    {
        set; get;
    }

    [ObservableProperty]
    public string _sprintTitle;

    public SprintDetailsViewModel(ITodoRepository todoRepository, ISprintRepository sprintRepository)
    {
         SprintTodoItems = new ObservableCollection<TodoModel>();
        _todoRepository = todoRepository;
        _sprintRepository = sprintRepository;
    }

    [RelayCommand]
    async void SprintTodoTapped(TodoModel sprintTodoItem)
    {
        if (IsBusy) return;
        IsBusy = true;
        await Shell.Current.GoToAsync(nameof(TodoDetailsView), true,
            new Dictionary<string, object>()
            {
                ["TodoModel"] = sprintTodoItem,
            });
        IsBusy = false;
    }

    [RelayCommand]
    async void Cancel()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    void IsCompleteTapped(TodoModel sprintTodoItem)
    {
        Task.Run(async () =>
        {
            await _todoRepository.SaveItem(sprintTodoItem.Todotable);
        });
    }

    [RelayCommand]
    async void AddTapped()
    {
        //need to pass in the sprint value for the current sprint from here
        if (IsBusy) return;
        IsBusy = true;
        await Shell.Current.GoToAsync(nameof(TodoDetailsView));
        IsBusy = false;
    }

    [RelayCommand]
    async void Back()
    {
        await Shell.Current.GoToAsync("..");
    }
    internal void Refresh()
    {
        if (IsBusy)
        {
            return;
        }
        IsBusy = true;

        Task.Run(() =>
        {
            SprintTitle = "Sprint " + SprintID.ToString();
            SprintTodoItems.Clear();
            SprintTodoTableItems.Sort((t1, t2) =>
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
            if (SprintTodoTableItems != null && SprintTodoTableItems.Count > 0)
            {
                SprintTodoTableItems.ForEach((st) => { SprintTodoItems.Add(new TodoModel(st)); });
            }
            IsBusy = false;
        });
    }
}
