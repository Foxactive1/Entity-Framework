# Entity-Framework
InnovaTasks/                    <-- pasta raiz do repositório
├─ src/
│  ├─ InnovaTasks.Api/          <-- Web API (project)
│  │  ├─ Controllers/
│  │  │   └─ TasksController.cs
│  │  ├─ DTOs/
│  │  │   ├─ TaskCreateDto.cs
│  │  │   └─ TaskReadDto.cs
│  │  ├─ Models/
│  │  │   └─ TaskItem.cs
│  │  ├─ Data/
│  │  │   └─ AppDbContext.cs
│  │  ├─ Repositories/
│  │  │   ├─ ITaskRepository.cs
│  │  │   └─ TaskRepository.cs
│  │  ├─ Services/
│  │  │   ├─ ITaskService.cs
│  │  │   └─ TaskService.cs
│  │  ├─ Migrations/             <-- gerado pelo EF migrations
│  │  ├─ appsettings.json
│  │  └─ Program.cs
│  └─ InnovaTasks.Web/           <-- (opcional) uma SPA simples ou index.html
├─ README.md
└─ .gitignore
