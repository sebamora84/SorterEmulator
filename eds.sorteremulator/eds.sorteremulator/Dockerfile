#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

EXPOSE 4949
EXPOSE 5002
EXPOSE 9999

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["eds.sorteremulator/eds.sorteremulator.csproj", "eds.sorteremulator/"]
COPY ["eds.sorteremulator.fileservices/eds.sorteremulator.fileservices.csproj", "eds.sorteremulator.fileservices/"]
COPY ["eds.sorteremulator.services/eds.sorteremulator.services.csproj", "eds.sorteremulator.services/"]
COPY ["eds.sorteremulator.configuration/eds.sorteremulator.configuration.csproj", "eds.sorteremulator.configuration/"]
COPY ["eds.sorteremulator.communication/eds.sorteremulator.communication.csproj", "eds.sorteremulator.communication/"]
RUN dotnet restore "eds.sorteremulator/eds.sorteremulator.csproj"
COPY . .
WORKDIR "/src/eds.sorteremulator"
RUN dotnet build "eds.sorteremulator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eds.sorteremulator.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eds.sorteremulator.dll"]