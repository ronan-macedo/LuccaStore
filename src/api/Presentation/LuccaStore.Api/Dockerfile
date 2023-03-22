#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/api/Presentation/LuccaStore.Api/LuccaStore.Api.csproj", "src/api/Presentation/LuccaStore.Api/"]
COPY ["src/api/Core/Application/LuccaStore.Core.Application/LuccaStore.Core.Application.csproj", "src/api/Core/Application/LuccaStore.Core.Application/"]
COPY ["src/api/Core/Domain/LuccaStore.Core.Domain/LuccaStore.Core.Domain.csproj", "src/api/Core/Domain/LuccaStore.Core.Domain/"]
COPY ["src/api/Infrastructure/LuccaStore.Infrastructure/LuccaStore.Infrastructure.csproj", "src/api/Infrastructure/LuccaStore.Infrastructure/"]
RUN dotnet restore "src/api/Presentation/LuccaStore.Api/LuccaStore.Api.csproj"
COPY . .
WORKDIR "/src/src/api/Presentation/LuccaStore.Api"
RUN dotnet build "LuccaStore.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LuccaStore.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LuccaStore.Api.dll"]