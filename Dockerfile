FROM mcr.microsoft.com/dotnet/sdk:8.0 AS builder

WORKDIR /src

COPY ProductApi.sln .
COPY Application/Application.csproj ./Application/
COPY Domain/Domain.csproj ./Domain/
COPY Infrastructure/Infrastructure.csproj ./Infrastructure/
COPY Api/Api.csproj ./Api/

RUN dotnet restore ProductApi.sln

COPY Application/ ./Application/
COPY Domain/ ./Domain/
COPY Infrastructure/ ./Infrastructure/
COPY Api/ ./Api/

ARG BUILD_CONFIGURATION=Release
RUN dotnet publish Api/Api.csproj \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    --no-self-contained \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

RUN apt-get update \
    && apt-get install -y --no-install-recommends \
       ca-certificates \
       openssl \
    && rm -rf /var/lib/apt/lists/*

ENV SSL_CERT_FILE=/etc/ssl/certs/ca-certificates.crt

WORKDIR /app

COPY --from=builder /app/publish ./

EXPOSE 80

ENTRYPOINT ["dotnet", "Api.dll"]