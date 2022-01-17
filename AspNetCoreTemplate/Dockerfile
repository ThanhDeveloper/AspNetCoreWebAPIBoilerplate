# syntax=docker/dockerfile:1
FROM node:16.11.1
FROM mcr.microsoft.com/dotnet/sdk:5.0
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_6.x | bash - && \
    apt-get install -y build-essential nodejs
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
RUN dotnet tool restore
EXPOSE 80/tcp
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh