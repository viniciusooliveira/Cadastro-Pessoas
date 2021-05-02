FROM node as build
WORKDIR /ui
COPY src ./src
COPY *.json ./
COPY *.conf ./
RUN npm install -g @angular/cli
RUN npm install
RUN ng build --prod

FROM nginx:alpine as deploy
WORKDIR /ui
COPY --from=build /ui/dist/UI/*.* /usr/share/nginx/html/
COPY ./nginx-custom.conf /etc/nginx/conf.d/default.conf
