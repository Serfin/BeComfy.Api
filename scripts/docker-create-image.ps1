# Config

$docker_username = "serfin"
$repository = "$docker_username/becomfy.api"
$tag = "0.0.1"

docker logout
docker login -u $docker_username -p $<secret>

docker build -t ${repository}:${tag} .
docker push ${repository}:${tag}