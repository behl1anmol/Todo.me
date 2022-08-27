namespace Todo.me.Model;
public class TodoModel
{
    private TodoTable _todoTable;
    public TodoTable Todotable
    {
        get => _todoTable; set
        {
            _todoTable = value;
        }
    }

    public TodoModel(TodoTable task = null)
    {
        Todotable = task != null ? task : new TodoTable();
    }

    public string Name
    {
        get => Todotable.Name;
        set
        {
            Todotable.Name = value;
        }
    }

    public int Id
    {
        get => Todotable.Id;
    }

    public int Color
    {
        get => Todotable.Color;
        set
        {
            Todotable.Color = value;
        }
    }
    public string Description
    {
        get => Todotable.Description;
        set
        {
            Todotable.Description = value;
        }
    }



    public bool IsComplete
    {
        get => Todotable.IsComplete;
        set => Todotable.IsComplete = value;
    }
}
