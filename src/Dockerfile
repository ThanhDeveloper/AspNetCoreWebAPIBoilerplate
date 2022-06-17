#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Project.API/Project.API.csproj", "Project.API/"]
COPY ["Project.Core/Project.Core.csproj", "Project.Core/"]
COPY ["Project.Data/Project.Data.csproj", "Project.Data/"]
COPY ["Project.Service/Project.Service.csproj", "Project.Service/"]
RUN dotnet restore "Project.API/Project.API.csproj"
COPY . .
WORKDIR "/src/Project.API"
RUN dotnet build "Project.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project.API.dll"]