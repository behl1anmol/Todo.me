using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Todo.me.Context;

namespace Todo.me.Repository;
public class SprintRepository : ISprintRepository
{
    private readonly TodoContext _dbContext;

    public SprintRepository(TodoContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task DeleteItem(int id)
    {
        var sprint = await _dbContext.Sprints.SingleOrDefaultAsync(x => x.Id == id);
        if (sprint != null)
        {
            _dbContext.Remove(sprint);
            await _dbContext.SaveChangesAsync();
        }
    }

    public Task<SprintTable?> GetItem(int id)
    {
        return _dbContext.Sprints.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<List<SprintTable>> GetItems()
    {
        return _dbContext.Sprints.Select(t => t).ToListAsync();
    }

    public async Task<SprintTable?> UpdateItem(SprintTable item)
    {
        var sprint = await _dbContext.Sprints.SingleOrDefaultAsync(x => x.Id == item.Id);
        if (sprint == null)
        {
            return sprint;
        }

        //sprint.Description = item.Description;
        //sprint.Name = item.Name;
        //sprint.IsComplete = item.IsComplete;
        //sprint.Color = item.Color;

        await _dbContext.SaveChangesAsync();
        return sprint;
    }

    public async Task<SprintTable> SaveItem(SprintTable item)
    {
        var sprint = await _dbContext.Sprints.SingleOrDefaultAsync(x => x.Id == item.Id);
        if (sprint != null)
        {
            sprint.SprintDuration = item.SprintDuration;
        }
        else
        {
            sprint = item;
            await _dbContext.Sprints.AddAsync(sprint);
        }
        await _dbContext.SaveChangesAsync();
        return sprint;
    }
}
