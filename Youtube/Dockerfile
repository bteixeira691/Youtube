FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Youtube/Youtube.csproj", "Youtube/"]
RUN dotnet restore "Youtube/Youtube.csproj"
COPY . .
WORKDIR "/src/Youtube"
RUN dotnet build "Youtube.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Youtube.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Youtube.dll"]