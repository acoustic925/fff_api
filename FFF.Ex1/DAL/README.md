# Генерация модели из готовой БД

Для генерации модели необходимо воспользоваться в Package Manager Console следующей командой (предварительно убрать разрывы строки):

```
Scaffold-DbContext
-f
-Connection "Server=CORSAIR;Database=fffdb;User Id=sa;Password=qwerty;"
-Provider Microsoft.EntityFrameworkCore.SqlServer
-OutputDir DAL/Models
-Tables data, query_log_action, service_log_action
-Project FFF.Ex1
-Context ServiceDbContext
```

В результате выполнения команды в папке Models будут созданы Entity и DbContext.
