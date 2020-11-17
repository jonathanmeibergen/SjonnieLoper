
## No backup files install ##

After isntalling docker be sure you have a group and
are added to the group.

**Post installation group actions**

Linux:
```
# Create the docker group.
sudo groupadd docker
# Add the user to the docker group.
sudo usermod -aG docker $(whoami)
# Log out and log back in to ensure docker runs with correct permissions.
sudo service docker start
```

Mac:
```
# Start virtual machine for docker
docker-machine start 
# It's helps to get environment variables
docker-machine env  
# Set environment variables
eval "$(docker-machine env default)"
```

**Create (and download SQL) SQL container**
```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=secret1234" -p <machineport>:<docker port> -d mcr.microsoft.com/mssql/server:2017-latest
```

mssql docker port is 1433 by default be carefull machine prot doesn't conflict wiht local port assignment.
