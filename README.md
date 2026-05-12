# LibraryDb — Библиотечна система

Проект за управление на библиотека, реализиран с **ASP.NET / .NET 8** и **Entity Framework Core** със **SQLite** база данни.

## Технологии

- .NET 8
- Entity Framework Core 8
- SQLite

## Структура на проекта

```
LibraryDb/
├── Models/
│   ├── Author.cs       # Автор
│   ├── Book.cs         # Книга
│   └── Category.cs     # Категория
├── Data/
│   └── LibraryContext.cs  # DbContext
├── Migrations/         # EF Core миграции
├── Program.cs          # Главен файл с примерни данни
├── LibraryDb.csproj    # Проектен файл
└── Доклад_LibraryDb.docx  # Документация
```

## Връзки между моделите

- **1→много**: `Author` → `Books` (един автор има много книги)
- **много↔много**: `Book` ↔ `Category` (книга има няколко категории и обратно) — реализирана с автоматично създадена join таблица `BookCategories`

## Стартиране

```bash
dotnet ef database update
dotnet run
```

При първо стартиране се добавят примерни данни:
- 3 автора (Оруел, Дойл, Хокинг)
- 4 книги
- 4 категории
- 6 връзки книга↔категория

## Таблици в базата

| Таблица | Записи |
|---------|--------|
| Authors | 3 |
| Books | 4 |
| Categories | 4 |
| BookCategories | 6 |
