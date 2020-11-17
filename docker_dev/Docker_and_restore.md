### Docker notes ###


Importing .bak backup files to container '/tmp/' dir 
requires the .bak file to be in the project root.
Zipped files are example backup files.

**Data backup file**

The build file specifies a relative path to our backup so
for the current target specified to work the file needs to be in
project root. If replace .bak file with current filename in root of file.


**Docker data target location**

The 'COPY' command in the build file is the exact same as the unix cp. 
So the 2nd argument is the location to copy to. Current location is '.'
since our docker file will live in the root of our project.


**Restore script db**

Just as the .bak file our restore script will be in project root.

In order for the restore script to work you need to know the names of
your 'Data' & 'Log' files. This can be done in a automated way but the 
easiest and fastest way is to run the following SQL command specifying
the full path to your .bak backup file:

```
RESTORE FILELISTONLY FROM DISK 'C:\dirname\Backup2020.bak'
```

Then place the results displayed under the 'LogicalName' column in the corresponding
locations.

For reference the file ending with 'Data' has to be moved over as '.mdf'
and the file ending with 'Log' will be our '.ldf' file in container. 

Example of MOVE command in restore script:
```
MOVE 'Backup_Data' TO '/var/opt/mssql/data/Backup.mdf'
MOVE 'Backup_Log' TO '/var/opt/mssql/data/Backup.ldf'
```


**Why 'sleep' after initial 'RUN' ?**

This is to allow the build and copy to
finish before any chained commands execute.
Increase time on slow build or setup.


**Why create a 'build' & 'final' server?**

The 'build' version will contain our backup files.
To prevent this from leaking into production and testing
we rebuild a server copying the generated files from the 
'build' server to the 'final' server.


**Login**

When using mssql login name will be 'sa' and the password
will be the one specified in build file.


**Building image**

To build run the following from shell specifying name and relative location:
```
docker build -t myrestored-db .
```
After the image is created there will be at least 3 db images,
- SQL official image
- Our restored db
- A intermediate image used as cache
The displayed file size for all three is not the actual size
since the are all sourced from the same image. So ther is just one.


**Run image**

To run the image enter the following in the shell:
```
docker run -p <localport>:<containerport> -d myrestored-db
```

Without build file and backup server it would be:
```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=1337entropy" -p 11433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
```

If the build fails and leaves your image half built you can run the following to delete broken images:
```
docker system prune -f
```

### Security for production etc ###

Sanitize data see examples, production data 
may be compromised.


**Restore and update db version**
Change versions after ':' in build file
and run:
```
docker rm <partial container ID>
```


