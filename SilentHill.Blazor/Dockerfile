FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["SilentHill.Blazor/SilentHill.Blazor.csproj", "SilentHill.Blazor/"]
COPY ["SilentHill.Shared/SilentHill.Shared.csproj", "SilentHill.Shared/"]

RUN dotnet restore "SilentHill.Blazor/SilentHill.Blazor.csproj"

COPY . .
WORKDIR "/src/SilentHill.Blazor"
RUN dotnet publish "SilentHill.Blazor.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

COPY --from=build /app/publish/wwwroot .

RUN rm /etc/nginx/conf.d/default.conf
RUN echo 'server { listen 80; location / { root /usr/share/nginx/html; try_files $uri $uri/ /index.html =404; } }' > /etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]