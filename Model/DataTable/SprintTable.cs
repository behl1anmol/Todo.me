using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Todo.me.Model.DataTable;
public class SprintTable
{

    [PrimaryKey]
    public int Id
    {
        set; get;
    }

    [ForeignKey(typeof(TodoTable))]
    public int TodoId
    {
        set; get;
    }


}
