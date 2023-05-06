FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /Cms/src
COPY ["src/Sadin.Cms.Api/Sadin.Cms.Api.csproj", "Sadin.Cms.Api/"]
COPY ["src/Sadin.Cms.Application/Sadin.Cms.Application.csproj", "Sadin.Cms.Application/"]
COPY ["src/Sadin.Cms.Domain/Sadin.Cms.Domain.csproj", "Sadin.Cms.Domain/"]
COPY ["src/Sadin.Cms.Shared/Sadin.Cms.Shared.csproj", "Sadin.Cms.Shared/"]
COPY ["src/Sadin.Cms.Infrastructure/Sadin.Cms.Infrastructure.csproj", "Sadin.Cms.Infrastructure/"]
COPY ["src/Sadin.Cms.Persistence/Sadin.Cms.Persistence.csproj", "Sadin.Cms.Persistence/"]
COPY ["src/Sadin.Cms.Presentation/Sadin.Cms.Presentation.csproj", "Sadin.Cms.Presentation/"]
RUN dotnet restore "/Cms/src/Sadin.Cms.Api/Sadin.Cms.Api.csproj"
COPY ./src .
WORKDIR "/Cms/src/Sadin.Cms.Api"
RUN dotnet build "Sadin.Cms.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sadin.Cms.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sadin.Cms.Api.dll"]
