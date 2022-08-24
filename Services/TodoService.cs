using SQLite;
using Todo.me.Model.DataTable;

namespace Todo.me.Services;
public class TodoService : ITodoService
{
    static SQLiteAsyncConnection Database;

    public static readonly LazyAsync<TodoService> Instance = new LazyAsync<TodoService>(async () =>
    {
        var instance = new TodoService();
        CreateTableResult result = await Database.CreateTableAsync<TodoTable>();
        return instance;
    });

    private TodoService()
    {
        Database = new SQLiteAsyncConnection(Constants.DbPath, Constants.Flags);
    }
    public Task<int> DeleteTodo(int id)
    {
        return Database.DeleteAsync(id);
    }
    public Task<TodoTable> GetTodo(int id)
    {
        return Database.Table<TodoTable>().Where((todo) => todo.Id == id).FirstOrDefaultAsync();
    } 
    public Task<List<TodoTable>> GetTodos()
    {
        return Database.Table<TodoTable>().ToListAsync();
    }
    public Task<int> SaveTodo(TodoTable todoTable)
    {

        if (todoTable.Id != 0)
        {
            return Database.UpdateAsync(todoTable);
        }
        return Database.InsertAsync(todoTable);
    }
}
