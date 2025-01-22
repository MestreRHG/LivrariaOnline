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
* Docker

To execute, all you need to do is run the following command:
```
# To run (add -d to run in the background)
docker-compose up

# To stop
docker-compose down
```

### 2. IIS
You need:
* IIS
* Docker
* Jenkins

Open the IIS Management application, and create a website with the name "LivrariaOnline" and the physical path to the "LivrariaOnline" folder.<br />
Then, open Jenkins and create a pipeline. On the advanced settings, set the pipeline script to the Jenkinsfile through the git repository. Alternatively, you can copy the content of the Jenkinsfile to the pipeline script. <br/>
Then, run the pipeline.

#### Development Notes (to be removed)
docker-compose up SqlServerDB