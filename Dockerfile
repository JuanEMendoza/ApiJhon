# Usa la imagen base de ASP.NET para tiempo de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Usa la imagen SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia el archivo de proyecto y restaura las dependencias
COPY ["Api.csproj", "./"]
RUN dotnet restore "Api.csproj"

# Copia todo el contenido del proyecto y compílalo
COPY . .
RUN dotnet build "Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publica el proyecto en modo Release
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagen final: más liviana, solo con el runtime
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
