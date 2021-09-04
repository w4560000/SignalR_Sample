#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SignalR_Server/SignalR_Server.csproj", "SignalR_Server/"]
RUN dotnet restore "SignalR_Server/SignalR_Server.csproj"
COPY . .
WORKDIR "/src/SignalR_Server"
RUN dotnet build "SignalR_Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SignalR_Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SignalR_Server.dll"]