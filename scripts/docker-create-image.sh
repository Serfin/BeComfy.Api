#!/bin/bash

clear

# Config

docker_username=serfin

image_name_tag=becomfy.api:0.0.1
repository=${docker_username}/becomfy.api

# Shell utilities

GREEN='\033[0;32m'
NC='\033[0m' # No Color

## Start

# printf "${GREEN}\n-> Sign in docker hub ${NC}\n\n"

# docker login -u ${docker_username} --password-stdin

# printf "${GREEN}\n-> Finish ${NC}\n\n"

printf "${GREEN}\n-> Creating docker image ${NC}\n\n"

docker build -t ${image_name_tag} .

printf "${GREEN}\n-> Finish ${NC}\n\n"

printf "${GREEN}\n-> Pushing image to docker hub ${NC}\n\n"

docker push ${image_name_tag}

printf "${GREEN}\n-> Finish ${NC}\n\n"