#Build
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build 
WORKDIR /source
COPY . .
RUN dotnet restore "WebAPI/WebAPI.csproj" --disable-parallel
RUN dotnet publish "WebAPI/WebAPI.csproj" -c release -o /app --no-restore

#Serve
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal 
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000
ENTRYPOINT ["dotnet","WebAPI.dll"]

#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
#WORKDIR /App
#
## Copy everything
#COPY . ./
## Restore as distinct layers
#RUN dotnet restore
## Build and publish a release
#RUN dotnet publish -c Release -o out
#
## Build runtime image
#FROM mcr.microsoft.com/dotnet/aspnet:6.0
#WORKDIR /App
#COPY --from=build-env /App/out .
#ENTRYPOINT ["dotnet", "WebAPI.dll"]


------React--------
#STAGE 1 
FROM node:18-alpine as builder
WORKDIR /app
COPY package.json .
COPY yarn.lock .
RUN yarn install
COPY . .
RUN yarn build

#Stage 2 
FROM nginx:1.19.00
WORKDIR /usr/share/nginx/html
RUN rm -rf ./*
COPY --from=builder /app/build .
ENTRYPOINT ["nginx","-g","daemon off;"]
---------------docker-compose.yml----------------
version: "3.8"

services:
   app:
	container_name: docker-react-c
	image: docker-react-i
	build: context: .
	ports:
	-8080:80