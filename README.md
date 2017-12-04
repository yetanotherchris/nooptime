## Introduction
Nooptime is an ASP.NET Core uptime monitor that runs in Docker and easy to extend via a simple plugin system.

### Technology

- ASP.NET Core MVC 2.0
- Postgres 9+ (using Marten as a NoSQL datastore)
- Docker for Linux (maybe Windows later)
- Front end technology TBD.

## Developing from the source

The following are required to develop NoopTime:

- Docker for Windows, or Docker for Mac OS X. This is for Postgres
- Some kind of IDE (VS2017 Community Edition or Visual Studio Code)
- NodeJS, used for `browserify'ing` the Vue.JS views.

## Setup

Docker compose is used for easier development (specifically, linked containers 
for a custom network). Install docker-compose and run `docker-compose up` in the 
web folder.

Alternatively you can do it outside of Docker-land, or at least the Nooptime part.

##### 1. Run Postgres in a docker container:

```
docker run -d -p 5432:5432 --name nooptime-postgres -e POSTGRES_USER=nooptime -e POSTGRES_PASSWORD=nooptime postgres
```

##### 2. Run Nooptime:

```
pushd .\src\Nooptime.Web\;
dotnet run -c Debug;

# When you exit
popd
```
