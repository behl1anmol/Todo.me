using Todo.me.Repository;

namespace Todo.me.ViewModel;

[INotifyPropertyChanged]
public partial class SprintViewModel : BaseViewModel
{
    private readonly ISprintRepository _sprintRepository;

    [ObservableProperty]
    public ObservableCollection<SprintModel> _sprintModels;


    public SprintViewModel(ISprintRepository sprintRepository)
    {
        SprintModels = new ObservableCollection<SprintModel>();
        _sprintRepository = sprintRepository;
    }

    [RelayCommand]
    async void SprintTapped(SprintModel sprintModel)
    {
        if (IsBusy) return;
        IsBusy = true;
        await Shell.Current.GoToAsync(nameof(SprintDetailsView), true,
            new Dictionary<string, object>()
            {
                ["SprintTodoTableItems"] = sprintModel.TodoItems,
                ["SprintID"] = sprintModel.Id
            });
        IsBusy = false;
    }

    [RelayCommand]
    void IsCompleteTapped(SprintModel sprintModel)
    {
        Task.Run(async () =>
        {
            //var service = await TodoService.Instance;
            await _sprintRepository.SaveItem(sprintModel.Sprinttable);
        });
    }
    [RelayCommand]
    async void AddTapped()
    {
        if (IsBusy) return;
        IsBusy = true;
        await Task.Run(async () =>
        {
            await _sprintRepository.SaveItem(new SprintTable
            {
                SprintDuration = 7
            });
        });
        IsBusy = false;
        Refresh();
    }

    [RelayCommand]
    async void GotoMainPage()
    {
        if (IsBusy) return;
        IsBusy = true;
        await Shell.Current.GoToAsync("..");
        IsBusy = false;
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
            var tasks = await _sprintRepository.GetItems();
            tasks.Sort((s1, s2) =>
            {
                return s1.Id < s2.Id ? -1 : 1;
            });
            return tasks;
        }).
        ContinueInMainThreadWith((sprintTables) =>
        {
            SprintModels.Clear();
            if (sprintTables != null && sprintTables.Count > 0)
            {
                sprintTables.ForEach((s) => { SprintModels.Add(new SprintModel(s)); });
            }

            IsBusy = false;
        });



    }
}
