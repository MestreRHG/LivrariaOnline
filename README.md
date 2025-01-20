# Livraria Online (WIP)

## What is it
This a school work made with [TLT](https://github.com/TLT99 "TLT's Github Page"). It's purpose is showing that we know how to use MVC (Model View Controller), docker, git and Jenkins.

## Using
### API
You can test the API by using the curl command
#### List of All Books: 
```
curl -X GET https://localhost:44301/api/books
```
#### List of All Books: 
```
curl -X POST "https://localhost:44301/api/makedelivery?bookId=2&userName=John%20Doe&address=123%20Main%20St" -H "Content-Type: application/json" -d "{}"
```

NOTE: Remember to change the localhost:44301 to your applications' address, or, if it is on localhost, you will probably still need to change the port.

## Running
There are two ways to run the app.

### 1. Docker Compose
You need:
* Visual Studio 2022 (with the ASP.NET component)
* Docker

To execute, all you need to do is open with Visual Studio, make sure "Docker-Compose" is selected, and run. It will then create the two containers and volume needed to run the sql server and website.

### 2. IIS
You need:
* IIS
* Jenkins

(WIP, needs info)

#### Development Notes (to be removed)
Put in jenkinsfile
docker-compose up SqlServerDB
dotnet build -c $configuration /p:DefineConstants="IIS"