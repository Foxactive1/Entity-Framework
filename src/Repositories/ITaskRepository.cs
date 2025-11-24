using InnovaTasks.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InnovaTasks.Api.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task AddAsync(TaskItem item);
        Task UpdateAsync(TaskItem item);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}
