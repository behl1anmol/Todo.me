//using SQLite;
//using SQLiteNetExtensions.Attributes;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.me.Model.DataTable;

[Table("Sprint")]
public class SprintTable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
        set; get;
    }

    public int SprintDuration
    {
        set; get;
    }

    public List<TodoTable> TodoItems
    {
        set; get;
    }


}
