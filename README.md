# 3 CONTINUAR A AULA MVC
    - Cria novo projeto Todo
    - Cria pasta Models
    - Cria Class TodoModels
    - propriedades: id, title, done, CreatedAt
    - Instalacoe dos pacote: dotnet add package Microsoft.EntityFrameworkCore.Sqlite ou SqlServer
    - Instalacoe dos pacote: dotnet add package Microsoft.EntityFrameworkCore.
    - Instalacoe dos pacote: dotnet add package Microsoft.EntityFrameworkCore.Design
    - Cria pasta Data
    - Cria class AppDbContext
        -Herança : DbContext
        -DbSet<TodoModel>Todo
        -Onconfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=app.db;Cache=Shared")
    - Dotnet ef migrations add CreateDateBase
    - dotnet ef database update
clear