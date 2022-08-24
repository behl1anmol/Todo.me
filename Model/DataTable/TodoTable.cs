using SQLite;

namespace Todo.me.Model.DataTable;
public class TodoTable
{
    [PrimaryKey, AutoIncrement]
    public int Id
    {
        set; get;
    }

    public string Name
    {
        set; get;
    }

    public string Description
    {
        set; get;
    }

    public bool IsComplete
    {
        set; get;
    }

    public int Color
    {
        set;
        get;
    }

}
