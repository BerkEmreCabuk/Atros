#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Atros.Api/Atros.Api.csproj", "Atros.Api/"]
RUN dotnet restore "Atros.Api/Atros.Api.csproj"
COPY . .
WORKDIR "/src/Atros.Api"
RUN dotnet build "Atros.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Atros.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Atros.Api.dll"]