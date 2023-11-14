cd /d %~dp0
dotnet test /p:CollectCoverage=true
reportgenerator -reports:TestResults/coverage.opencover.xml -targetdir:CodeCoverage