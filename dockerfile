# Etapa de preparacion (INSTALACION DE SDK)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Etapa copiado de archivos de proyecto 
COPY ["EM.Pedido.UI/EM.Pedido.UI.csproj", "EM.Pedido.UI/"]
COPY ["EM.Pedido.Utils/EM.Pedido.Utils.csproj", "EM.Pedido.Utils/"]
COPY ["EM.Pedido.DTO/EM.Pedido.DTO.csproj", "EM.Pedido.DTO/"]
COPY ["EM.Pedido.Business/EM.Pedido.Business.csproj", "EM.Pedido.Business/"]
COPY ["EM.Pedido.Entities/EM.Pedido.Entities.csproj", "EM.Pedido.Entities/"]
COPY ["EM.Pedido.DataAccess/EM.Pedido.DataAccess.csproj", "EM.Pedido.DataAccess/"]
COPY . .

# Etapa de restaurar dependencias y construir la aplicacion
RUN dotnet restore "EM.Pedido.UI/EM.Pedido.UI.csproj"
RUN dotnet publis "EM.Pedido.UI/EM.Pedido.UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

#Instalación de runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
COPY --from=buid /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "EM.Pedido.UI.dll"]
