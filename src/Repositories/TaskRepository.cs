using InnovaTasks.Api.Data;
using InnovaTasks.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InnovaTasks.Api.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _db;
        public TaskRepository(AppDbContext db) => _db = db;

        public async Task AddAsync(TaskItem item)
        {
            await _db.Tasks.AddAsync(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _db.Tasks.FindAsync(id);
            if (entity != null)
                _db.Tasks.Remove(entity);
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _db.Tasks.AsNoTracking().ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            return await _db.Tasks.FindAsync(id);
        }

        public Task UpdateAsync(TaskItem item)
        {
            _db.Tasks.Update(item);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync() => await _db.SaveChangesAsync();
    }
}
