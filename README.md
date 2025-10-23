# TaskManager - ASP.NET Core приложение
## Основные функции:
  регистрация и авторизация
  создание своих задач
  возможность отмечать выполненные задачи
  хранение данных в собственной базе данных
## Требования
SQL Server Express или LocalD (устанавливается с Visual Studio)
## Запуск проекта локально
  1. Клонирование репозитория.
  2. Строка подключения к БД хранится в secrets.json. На примере MS SQL LocalDB, чтобы задать свою строку подключения:
     '''bash
     dotnet user-secrets set "ConnectionStrings:DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=aspnet-TaskManager;Trusted_Connection=True;MultipleActiveResultSets=true"
  4. Применить миграции и создать базу данных:
     '''bash
     dotnet ef database update
##Аутентификация
Приложение использует стандартный ASP.NET Core Identity.
ПОст-запросы и изменения доступны только авторизованным пользователям.
