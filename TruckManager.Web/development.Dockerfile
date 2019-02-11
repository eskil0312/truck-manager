
FROM node:8.7.0-alpine

RUN mkdir -p /srv/app/truckmanager-client
WORKDIR /srv/app/truckmanager-client

ENV PATH /srv/app/truckmanager-client/node_modules/.bin:$PATH

COPY package.json /srv/app/truckmanager-client
COPY package-lock.json /srv/app/truckmanager-client

RUN npm install

COPY . /srv/app/truckmanager-client

CMD ["npm", "start"]
