FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TbcToMarkdown/TbcToMarkdown.csproj", "TbcToMarkdown/"]
RUN dotnet restore "TbcToMarkdown/TbcToMarkdown.csproj"
COPY . .
WORKDIR "/src/TbcToMarkdown"
RUN dotnet build "TbcToMarkdown.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TbcToMarkdown.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TbcToMarkdown.dll"]
