FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["CarBookingAPI.csproj", ""]
RUN dotnet restore "CarBookingAPI.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "CarBookingAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CarBookingAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CarBookingAPI.dll"]