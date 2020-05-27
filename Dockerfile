FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS builder
WORKDIR /app
COPY . .
RUN dotnet publish src/BeComfy.Api -c Release -o BeComfy.Api_Release

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim
WORKDIR /app
COPY --from=builder /app/BeComfy.Api_Release .
ENV ASPNETCORE_ENVIRONMENT Release
EXPOSE 5000
ENTRYPOINT dotnet BeComfy.Api.dll