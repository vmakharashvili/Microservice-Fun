#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
EXPOSE 8080

COPY *.csproj ./
RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "MicroserviceFun.Users.dll" ]

#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["MicroserviceFun.Users/MicroserviceFun.Users.csproj", "MicroserviceFun.Users/"]
#RUN dotnet restore "MicroserviceFun.Users/MicroserviceFun.Users.csproj"
#COPY . .
#WORKDIR "/src/MicroserviceFun.Users"
#RUN dotnet build "MicroserviceFun.Users.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "MicroserviceFun.Users.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "MicroserviceFun.Users.dll"]