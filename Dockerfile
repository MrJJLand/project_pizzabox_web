FROM mcr.microsoft.com/dotnet/sdk AS starter

WORKDIR /app
COPY . .
RUN dotnet build
RUN dotnet publish --configuration Debug -o out PizzaBox.Client

FROM mcr.microsoft.com/dotnet/aspnet

WORKDIR /run
COPY --from=starter /app/out .
CMD [ "dotnet", "PizzaBox.Client.dll" ]