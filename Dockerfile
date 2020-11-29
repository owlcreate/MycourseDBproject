FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["nscccoursemap-matchacode.csproj", "./"]
RUN dotnet restore "./nscccoursemap-matchacode.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "nscccoursemap-matchacode.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "nscccoursemap-matchacode.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "nscccoursemap-matchacode.dll"]
