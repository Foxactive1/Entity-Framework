using InnovaTasks.Api.DTOs;
using InnovaTasks.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InnovaTasks.Api.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskReadDto>> GetAllAsync();
        Task<TaskReadDto?> GetByIdAsync(Guid id);
        Task<TaskReadDto> CreateAsync(TaskCreateDto dto);
        Task<bool> UpdateAsync(Guid id, TaskCreateDto dto);
        Task<bool> SetCompletedAsync(Guid id, bool completed);
        Task<bool> DeleteAsync(Guid id);
    }
}
