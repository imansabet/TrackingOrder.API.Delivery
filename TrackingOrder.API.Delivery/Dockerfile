FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /TrackingOrder.API.Delivery

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /TrackingOrder.API.Delivery
COPY --from=build-env /TrackingOrder.API.Delivery/out .
ENTRYPOINT ["dotnet", "TrackingOrder.API.Delivery.dll"]