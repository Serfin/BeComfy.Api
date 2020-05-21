# Build Becomfy.Api using sdk 

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS builder
WORKDIR /app
COPY . .
RUN dotnet publish src/BeComfy.Api -c Release -o BeComfy.Api_Release


# Create image with runtime

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=builder /app/src/BeComfy.Api/BeComfy.Api_Release .

ENV ASPNETCORE_ENVIRONMENT Release
EXPOSE 5000
ENTRYPOINT dotnet BeComfy.Api.dll