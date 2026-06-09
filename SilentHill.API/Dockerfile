FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["SilentHill.API/SilentHill.API.csproj", "SilentHill.API/"]
COPY ["SilentHill.Application/SilentHill.Application.csproj", "SilentHill.Application/"]
COPY ["SilentHill.Domain/SilentHill.Domain.csproj", "SilentHill.Domain/"]
COPY ["SilentHill.Infrastructure/SilentHill.Infrastructure.csproj", "SilentHill.Infrastructure/"]
COPY ["SilentHill.Shared/SilentHill.Shared.csproj", "SilentHill.Shared/"]

RUN dotnet restore "SilentHill.API/SilentHill.API.csproj"

COPY . .
WORKDIR "/src/SilentHill.API"
RUN dotnet build "SilentHill.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SilentHill.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "SilentHill.API.dll"]