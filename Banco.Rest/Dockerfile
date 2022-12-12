#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Banco.Rest/Banco.Rest.csproj", "Banco.Rest/"]
COPY ["Banco.DataAccess/Banco.DataAccess.csproj", "Banco.DataAccess/"]
COPY ["Banco.Core/Banco.Core.csproj", "Banco.Core/"]
COPY ["Banco.Services/Banco.Services.csproj", "Banco.Services/"]
RUN dotnet restore "Banco.Rest/Banco.Rest.csproj"
COPY . .
WORKDIR "/src/Banco.Rest"
RUN dotnet build "Banco.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Banco.Rest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Banco.Rest.dll"]