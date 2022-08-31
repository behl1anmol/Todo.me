using Todo.me.Model;

namespace Todo.me.ViewModel;
public abstract class BaseViewModel
{
    private bool isBusy;
    public bool IsBusy
    {
        get => isBusy;
        set
        {
            isBusy = value;
        }
    }

    public int RandomGenerator()
    {
        Random rnd = new Random();

        return rnd.Next(1,11);
    }
}
