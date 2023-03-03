# BeyondSports.Assessment

To run the project, you can run it directly by command
```console
$ cd BeyondSports.Assessment.API
$ dotnet run
```
or you can run it with Docker
```console
$ docker build -t kouhestani-assesssment -f .\BeyondSports.Assessment.API\Dockerfile .
$ docker run -it -p 5142:80 kouhestani-assesssment
```

and then open th URL `http://localhost:5142/swagger` to see the documentations.
