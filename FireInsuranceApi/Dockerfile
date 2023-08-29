#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FireInsuranceApi/FireInsuranceApi.csproj", "FireInsuranceApi/"]
RUN dotnet restore "FireInsuranceApi/FireInsuranceApi.csproj"
COPY . .
WORKDIR "/src/FireInsuranceApi"
RUN dotnet build "FireInsuranceApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FireInsuranceApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FireInsuranceApi.dll"]