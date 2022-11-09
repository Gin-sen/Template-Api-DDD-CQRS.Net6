#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["My.DDD.CQRS.Temp6.WorkService/My.DDD.CQRS.Temp6.WorkService.csproj", "My.DDD.CQRS.Temp6.WorkService/"]
RUN dotnet restore "My.DDD.CQRS.Temp6.WorkService/My.DDD.CQRS.Temp6.WorkService.csproj"
COPY . .
WORKDIR "/src/My.DDD.CQRS.Temp6.WorkService"
RUN dotnet build "My.DDD.CQRS.Temp6.WorkService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "My.DDD.CQRS.Temp6.WorkService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "My.DDD.CQRS.Temp6.WorkService.dll"]