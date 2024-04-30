dotnet clean

dotnet publish BooksUi -c Release
dotnet publish BooksApi --self-contained -r linux-x64 -c Release

cf push