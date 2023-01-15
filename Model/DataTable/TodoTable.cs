//using SQLite;


using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.me.Model.DataTable;

[Table("Todo")]
public class TodoTable
{
    [System.ComponentModel.DataAnnotations.Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
