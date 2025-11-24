using System;
using System.ComponentModel.DataAnnotations;

namespace InnovaTasks.Api.DTOs
{
    public class TaskCreateDto
    {
        [Required, MaxLength(200)]
        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime? DueAt { get; set; }
    }
}
