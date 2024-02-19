FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /source

ENV ASPNETCORE_URLS=http://+:3000

COPY *.sln .

COPY src/RinhaDeDev.WebApi/ src/RinhaDeDev.WebApi/
COPY src/RinhaDeDev.Infrastructure/ src/RinhaDeDev.Infrastructure/
COPY src/RinhaDeDev.Application/ src/RinhaDeDev.Application/
COPY src/RinhaDeDev.Domain/ src/RinhaDeDev.Domain/
COPY tests/RinhaDeDev.WebApi.Tests/ tests/RinhaDeDev.WebApi.Tests/
COPY tests/RinhaDeDev.Infrastructure.Tests/ tests/RinhaDeDev.Infrastructure.Tests/
COPY tests/RinhaDeDev.Application.Tests/ tests/RinhaDeDev.Application.Tests/
COPY tests/RinhaDeDev.Domain.Tests/ tests/RinhaDeDev.Domain.Tests/

WORKDIR /source/src/RinhaDeDev.WebApi
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 3000
COPY --from=build /app .
ENTRYPOINT ["dotnet", "RinhaDeDev.WebApi.dll"]