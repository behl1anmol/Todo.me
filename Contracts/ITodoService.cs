namespace Todo.me.Contracts;
public interface ITodoService
{
    Task<List<TodoTable>> GetTodos();
    Task<TodoTable> GetTodo(int id);
    Task<int> DeleteTodo(int id);
    Task<int> SaveTodo(TodoTable todoTable);
}
