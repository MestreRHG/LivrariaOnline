# Livraria Online (WIP)

## What is it
This a school work made with [TLT](https://github.com/TLT99 "TLT's Github Page"). It's purpose is showing that we know how to use MVC (Model View Controller), docker, git and Jenkins.

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