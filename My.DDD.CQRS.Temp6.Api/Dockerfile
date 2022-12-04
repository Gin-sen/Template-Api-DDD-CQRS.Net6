#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["My.DDD.CQRS.Temp6.Api/My.DDD.CQRS.Temp6.Api.csproj", "My.DDD.CQRS.Temp6.Api/"]
COPY ["My.DDD.CQRS.Temp6.Application/My.DDD.CQRS.Temp6.Application.csproj", "My.DDD.CQRS.Temp6.Application/"]
COPY ["My.DDD.CQRS.Temp6.Contracts/My.DDD.CQRS.Temp6.Contracts.csproj", "My.DDD.CQRS.Temp6.Contracts/"]
COPY ["MY.DDD.CQRS.Temp6.CQRS/MY.DDD.CQRS.Temp6.CQRS.csproj", "MY.DDD.CQRS.Temp6.CQRS/"]
COPY ["My.DDD.CQRS.Temp6.Domain/My.DDD.CQRS.Temp6.Domain.csproj", "My.DDD.CQRS.Temp6.Domain/"]
COPY ["My.DDD.CQRS.Temp6.DBAccess/My.DDD.CQRS.Temp6.DBAccess.csproj", "My.DDD.CQRS.Temp6.DBAccess/"]
COPY ["My.DDD.CQRS.Temp6.Http.Bootstrap/My.DDD.CQRS.Temp6.Http.Bootstrap.csproj", "My.DDD.CQRS.Temp6.Http.Bootstrap/"]
COPY ["My.DDD.CQRS.Temp6.AzureTables/My.DDD.CQRS.Temp6.AzureTables.csproj", "My.DDD.CQRS.Temp6.AzureTables/"]
COPY ["My.DDD.CQRS.Temp6.AzureStorage/My.DDD.CQRS.Temp6.AzureStorage.csproj", "My.DDD.CQRS.Temp6.AzureStorage/"]
COPY ["My.DDD.CQRS.Temp6.HttpClients/My.DDD.CQRS.Temp6.HttpClients.csproj", "My.DDD.CQRS.Temp6.HttpClients/"]
COPY ["My.DDD.CQRS.Temp6.Logging/My.DDD.CQRS.Temp6.Logging.csproj", "My.DDD.CQRS.Temp6.Logging/"]
RUN dotnet restore "My.DDD.CQRS.Temp6.Api/My.DDD.CQRS.Temp6.Api.csproj"
COPY . .
WORKDIR "/src/My.DDD.CQRS.Temp6.Api"
RUN dotnet build "My.DDD.CQRS.Temp6.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "My.DDD.CQRS.Temp6.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "My.DDD.CQRS.Temp6.Api.dll"]