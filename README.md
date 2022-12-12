# TestTask

1. качаем репозиторий.
2. выполняем команду в терминале PowerShell: docker-compose up, тем самым создаем контейнеры для сервера и базы данных postgreSql
3. в классе TT_DB_Context.cs есль закоменированная строчка подключения к бд. копируем ее в appsettings и в терминале PackageManager выполняем команду: update-database initial
4. далее перезапускаем контейнер tt_aspnetcore, или перезапускаем все с помощью docker compose up.
5. переходим на http://localhost:5000/swagger/index.html  
