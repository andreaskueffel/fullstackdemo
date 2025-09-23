ARG newversion=1.0.0

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ARG newversion
WORKDIR /app
EXPOSE 8080


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG newversion
WORKDIR /src
COPY . .
RUN dotnet publish -r linux-x64 -c Release -f net8.0 -p:Version=$newversion -o /app/build 
#RUN chmod -R guo+rwx /app/build


FROM base AS final
WORKDIR /app

COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "MachineLicenseManagement.WebKeyGen.dll"]

