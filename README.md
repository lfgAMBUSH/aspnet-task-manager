# TaskManager - ASP.NET Core приложение
## Основные функции:
- регистрация и авторизация
- создание своих задач
- возможность отмечать выполненные задачи
- хранение данных в собственной базе данных PostgreSQL
## Требования
PostgreSQL
## Запуск проекта локально
  1. Клонирование репозитория.
  2. Строка подключения к БД хранится в secrets.json. Чтобы задать свою строку подключения:
     ```bash
     dotnet user-secrets set "ConnectionStrings:DefaultConnection": "Host=<...>;Port=<...>;Database=taskmanagerDB;Username=<...>;Password=<...>"
  4. Применить миграции и создать базу данных:
     ```bash
     dotnet ef database update
## Аутентификация
Приложение использует стандартный ASP.NET Core Identity.
POST-запросы и изменения доступны только авторизованным пользователям.
