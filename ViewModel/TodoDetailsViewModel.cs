using Todo.me.Repository;

namespace Todo.me.ViewModel;


[INotifyPropertyChanged]
[QueryProperty(nameof(TodoModel), nameof(TodoModel))]

public partial class TodoDetailsViewModel : BaseViewModel
{
    public AppThemeService _appTheme;

    private readonly ITodoRepository _todoRepository;
    private readonly ISprintRepository _sprintRepository;

    [ObservableProperty]
    private TodoModel _todoModel;

    [ObservableProperty]
    private SprintModel _selectedSprint;

    public ObservableCollection<SprintModel> SprintModels
    {
        private set; get;
    } = new ObservableCollection<SprintModel>();


    public TodoDetailsViewModel(AppThemeService appTheme, ITodoRepository _todoRepository, ISprintRepository sprintRepository)
    {
        TodoModel = new TodoModel();
        this._todoRepository = _todoRepository;
        _sprintRepository = sprintRepository;
    }

    [RelayCommand]
    void Save()
    {
        var temp = SelectedSprint;
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
                TodoModel.SprintID = SelectedSprint.Id;
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
    internal void Refresh()
    {
        if (IsBusy)
        {
            return;
        }
        IsBusy = true;

        Task.Run<List<SprintTable>>(async () =>
        {
            List<SprintTable> tasks = await _sprintRepository.GetItems();
            //if no sprint exist create a new sprint with default duration as 7
            if (tasks.Count() == 0)
            {
                var task = new SprintTable()
                {
                    SprintDuration = 7
                };
                await _sprintRepository.SaveItem(task);
                tasks.Add(task);
            }
            return tasks;
        }).
        ContinueInMainThreadWith((sprintTables) =>
        {
            if (sprintTables != null && sprintTables.Count > 0)
            {
                sprintTables.ForEach((t) =>
                {
                    SprintModels.Add(new SprintModel(t));
                });
                SelectedSprint = SprintModels.Where(s => s.Id.Equals(TodoModel.SprintID)).FirstOrDefault();
            }

            IsBusy = false;
        });
    }

}
