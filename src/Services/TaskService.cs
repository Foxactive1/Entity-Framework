using InnovaTasks.Api.DTOs;
using InnovaTasks.Api.Models;
using InnovaTasks.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovaTasks.Api.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repo;
        public TaskService(ITaskRepository repo) => _repo = repo;

        public async Task<TaskReadDto> CreateAsync(TaskCreateDto dto)
        {
            var model = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                DueAt = dto.DueAt
            };
            await _repo.AddAsync(model);
            await _repo.SaveChangesAsync();

            return MapToReadDto(model);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _repo.DeleteAsync(id);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TaskReadDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return items.Select(MapToReadDto);
        }

        public async Task<TaskReadDto?> GetByIdAsync(Guid id)
        {
            var item = await _repo.GetByIdAsync(id);
            return item == null ? null : MapToReadDto(item);
        }

        public async Task<bool> SetCompletedAsync(Guid id, bool completed)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return false;
            item.IsCompleted = completed;
            await _repo.UpdateAsync(item);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Guid id, TaskCreateDto dto)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return false;
            item.Title = dto.Title;
            item.Description = dto.Description;
            item.DueAt = dto.DueAt;
            await _repo.UpdateAsync(item);
            await _repo.SaveChangesAsync();
            return true;
        }

        private TaskReadDto MapToReadDto(TaskItem item) =>
            new TaskReadDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted,
                DueAt = item.DueAt,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt
            };
    }
}
