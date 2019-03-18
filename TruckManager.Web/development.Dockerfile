
FROM node:8.7.0-alpine

RUN mkdir -p /src/app/truckmanager-client
WORKDIR /src/app/truckmanager-client

ENV PATH /src/app/truckmanager-client/node_modules/.bin:$PATH

COPY package.json /src/app/truckmanager-client
COPY package-lock.json /src/app/truckmanager-client

RUN npm install

COPY . /src/app/truckmanager-client

CMD ["npm", "start"]
