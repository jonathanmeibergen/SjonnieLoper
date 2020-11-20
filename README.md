### SjonnieLoper webapp ###


...
...
...

## Docker quickstart ##


- Containers
 - MSSQL_Sjonnie
 - redis_Sjonnie

To use sql or redis from the containers set connection string in startup.cs to
"DockerSqlConnection" for sql or "DockerSqlConnection" for redis.


Docker services can be managed using the desktop app or Visual studio built in tools.


# Install desktop app and/or  cli tools #


*Mac desktop app*
Includes compose tools and standard tools needed.
This includes the app and cli tools.

https://docs.docker.com/docker-for-mac/install/



# Initial build and start #


To start up the containers run the following commands in the 'docker_files' folder.

To create and start the containers run the following command, -d detaches
your terminal from the session. Commands for managing just a single container at bottom.

```
docker-compose up -d
```

*Rebuild containers if needed*

```
docker-compose build
```

*Start containers*

```
docker-compose start
```

*Restart containers*

```
docker-compose restart
```

*Stop containers*

```
docker-compose stop
```

*View containers status*

Lists all active containers:
```
docker container ps
```

List active & inactive containers:

```
docker container ps -a
```

# Single container #

To select a single container you only have to specify
the start of a container id listed by 'docker container ps'.

Start:
```
docker container start <container id full or partial>
```
Stop:
```
docker container stop <container id full or partial>
```
Delete:
```
docker container rm <container id full or partial>
```
