# Compiling the angular app
FROM node:16-slim as build

# Setting up working directory
WORKDIR /build
COPY . /build

# installing dependencies
RUN npm ci
RUN npm run build

# Executing the application
FROM nginx:stable-alpine

COPY --from=build /build/dist/customer-support-form /usr/share/nginx/html

# Exposing port 80
EXPOSE 80

STOPSIGNAL SIGQUIT

CMD ["nginx", "-g", "daemon off;"]
