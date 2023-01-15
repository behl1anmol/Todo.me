using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.me.Repository;
public interface IBaseRepository<T> where T : new()
{
    Task DeleteItem(int id);
    Task<T?> GetItem(int id);
    Task<List<T>> GetItems();
    Task<T?> UpdateItem(T item);
    Task<T> SaveItem(T item);
}
