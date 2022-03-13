FROM microsoft/dotnet:2.0-sdk AS build
COPY APITest/*.csproj ./app/APITest/
WORKDIR /app/APITest
RUN dotnet restore

COPY APITest/. ./
RUN dotnet publish -o out /p:PublishWithAspNetCoreTargetManifest="false"

FROM microsoft/dotnet:2.0-runtime AS runtime
ENV ASPNETCORE_URLS http://+:80
WORKDIR /app
COPY --from=build /app/APITest/out ./
ENTRYPOINT ["dotnet", "APITest.dll"]



