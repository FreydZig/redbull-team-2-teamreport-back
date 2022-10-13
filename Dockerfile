FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
# <add your commands here>

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CM.TeamReportAPI/CM.TeamReportAPI.csproj", "CM.TeamReportAPI/"]
RUN dotnet restore "CM.TeamReportAPI/CM.TeamReportAPI.csproj"
COPY . .
WORKDIR "src/CM.TeamReportAPI"
RUN dotnet build "CM.TeamReportAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CM.TeamReportAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CM.TeamReportAPI.dll"]