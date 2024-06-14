Перед первым запуском - установите генератор отчетов как глобальный инструмент, выполнив `dotnet tool install -g dotnet-reportgenerator-globaltool`

1) Перейдите в папку `GeometryLibrary.Tests`
1) Удалите папку `TestResults`
2) Запустите тесты со сбором данных о покрытии `dotnet test --collect:"XPlat Code Coverage"`
3) Сформируйте отчёт `reportgenerator -reports:"TestResults/**/coverage.cobertura.xml" -targetdir:"coverage-report" -reporttypes:Html`
4) Откройте `index.html`

//Todo: автоматизировать