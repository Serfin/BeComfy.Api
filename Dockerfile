FROM mcr.microsoft.com/dotnet/core/sdk:3.0
WORKDIR /app
COPY ./src/BeComfy.Api/bin/Release/netcoreapp3.0 .
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT Release
EXPOSE 5000
ENTRYPOINT ["dotnet", "BeComfy.Api.dll"]