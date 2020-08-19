FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/ShopCart.API/ShopCart.API.csproj", "src/ShopCart.API/"]
RUN dotnet restore "src/ShopCart.API/ShopCart.API.csproj"
COPY . .
WORKDIR "/src/src/ShopCart.API"
RUN dotnet build "ShopCart.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopCart.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopCart.API.dll"]