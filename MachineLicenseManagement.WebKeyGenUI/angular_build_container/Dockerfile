FROM node:lts
USER root
RUN mkdir -p /source/node_modules
RUN chmod 777 /source/node_modules
RUN apt-get update && apt-get install -y zip
ADD https://awscli.amazonaws.com/awscli-exe-linux-x86_64.zip /aws/awscliv2.zip 
WORKDIR /aws
RUN unzip /aws/awscliv2.zip
RUN ./aws/install
ENV NODE_OPTIONS=--max_old_space_size=4096
RUN npm install -y -g npm@latest
RUN npm install -y -g @angular/cli@20
ENV NG_CLI_ANALYTICS=false
RUN usermod -a -G root node 
RUN groupadd -g 1002 jenkins && useradd jenkins -u 1002 -g 1002 -ms /bin/bash
USER node
