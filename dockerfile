FROM mcr.microsoft.com/mssql/server:2017-latest
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=1337entropy

WORKDIR /tmp

RUN mkdir /var/opt/mssql
RUN mkdir /var/opt/mssql/data
RUN mkdir /var/opt/mssql/log
RUN mkdir /var/opt/mssql/backup

RUN chown -R mssql:mssql /var/opt/mssql
RUN chown -R mssql:mssql /var/opt/mssql

USER mssql

CMD /opt/mssql/bin/sqlservr
