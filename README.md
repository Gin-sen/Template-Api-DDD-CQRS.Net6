# My.DDD.CQRS.Temp6.Api

# Installation de la template

Prérequis : .Net SDK

Cloner le dépot de la solution.
Dans un terminal, à la racine du dépot, entrer la commande :
`dotnet new install .`
Cela rendra la template disponible dans Visual Studio (nouveau projet) et avec la commande :
`dotnet new my-ddd-api -n VOTRE.NOUVEAU.MICROSERVICE`

2 cas de figure:
1. Cloner un nouveau dépot vide puis dans ce dépot, lancer :
`dotnet new my-ddd-api -n VOTRE.NOUVEAU.MICROSERVICE -o .`
2. Créer la solution avec la commande suivante puis initialiser votre dépot à partir du nouveau dossier de solution
`dotnet new my-ddd-api -n VOTRE.NOUVEAU.MICROSERVICE`

Note:
Si vous utilisez l'option de template `-in false` ou `--includeTest false`, il faudra supprimer les projets de tests de votre solution.

Pour lister les templates installées :
`dotnet new --list`

Pour désinstaller la template, dans un terminal, à la racine du dépot, entrez la commande :
`dotnet new uninstall .`

# Docker Compose

4 profils :
- Docker Compose (API + BDD)
- With ELK (API + BDD + ELK)
- Setup ELK (ELK + Setup)
- Reboot ELK (ELK)

En cas de soucis avec ELK (Docker Desktop pour Windows):

1. Ajoutez de la RAM à Docker (.wslconfig)

2. Erreur de type "max virtual memory areas vm.max_map_count is too low", ouvrez un PowerShell :

```bash
wsl -d docker-desktop
sysctl -w vm.max_map_count=262144
```

Au premier lancement, vous devrez changer les mots de passe et remplacer les valeurs dans le .env :

````bash
docker exec -it elasticsearch /usr/share/elasticsearch/bin/elasticsearch-reset-password -u elastic
docker exec -it elasticsearch /usr/share/elasticsearch/bin/elasticsearch-reset-password -u kibana_system
docker exec -it elasticsearch /usr/share/elasticsearch/bin/elasticsearch-reset-password -u logstash_internal
docker exec -it elasticsearch /usr/share/elasticsearch/bin/elasticsearch-reset-password -u logstash_writer
docker exec -it elasticsearch /usr/share/elasticsearch/bin/elasticsearch-reset-password -u filebeat_internal
docker exec -it elasticsearch /usr/share/elasticsearch/bin/elasticsearch-reset-password -u filebeat_writer
docker exec -it elasticsearch /usr/share/elasticsearch/bin/elasticsearch-reset-password -u metricbeat_internal
docker exec -it elasticsearch /usr/share/elasticsearch/bin/elasticsearch-reset-password -u metricbeat_writer
docker exec -it elasticsearch /usr/share/elasticsearch/bin/elasticsearch-reset-password -u monitoring_internal
docker exec -it elasticsearch /usr/share/elasticsearch/bin/elasticsearch-reset-password -u beats_system

```

<details>
<summary>One liners (Linux only)</summary>
```bash
ELASTIC=$(docker exec -it elasticsearch bin/elasticsearch-reset-password --batch --user elastic | grep New | cut -d ' ' -f 3 | sed -r "s/[\r\n]+//" -); sed -i -r "s/^(ELASTIC_PASSWORD=).*/\1'$ELASTIC'/" .env
LOGSTASH_INTERNAL=$(docker exec -it elasticsearch bin/elasticsearch-reset-password --batch --user logstash_internal | grep New | cut -d ' ' -f 3 | sed -r "s/[\r\n]+//" -); sed -i -r "s/^(LOGSTASH_INTERNAL_PASSWORD=).*/\1'$LOGSTASH_INTERNAL'/" .env
KIBANA=$(docker exec -it elasticsearch bin/elasticsearch-reset-password --batch --user kibana_system | grep New | cut -d ' ' -f 3 | sed -r "s/[\r\n]+//" -); sed -i -r "s/^(KIBANA_SYSTEM_PASSWORD=).*/\1'$KIBANA'/" .env
FILEBEAT=$(docker exec -it elasticsearch bin/elasticsearch-reset-password --batch --user filebeat_internal | grep New | cut -d ' ' -f 3 | sed -r "s/[\r\n]+//" -); sed -i -r "s/^(FILEBEAT_INTERNAL_PASSWORD=).*/\1'$FILEBEAT'/" .env
METRICBEAT=$(docker exec -it elasticsearch bin/elasticsearch-reset-password --batch --user metricbeat_internal | grep New | cut -d ' ' -f 3 | sed -r "s/[\r\n]+//" -); sed -i -r "s/^(METRICBEAT_INTERNAL_PASSWORD=).*/\1'$METRICBEAT'/" .env
HEARTBEAT=$(docker exec -it elasticsearch bin/elasticsearch-reset-password --batch --user heartbeat_internal | grep New | cut -d ' ' -f 3 | sed -r "s/[\r\n]+//" -); sed -i -r "s/^(HEARTBEAT_INTERNAL_PASSWORD=).*/\1'$HEARTBEAT'/" .env
MONITORING=$(docker exec -it elasticsearch bin/elasticsearch-reset-password --batch --user monitoring_internal | grep New | cut -d ' ' -f 3 | sed -r "s/[\r\n]+//" -); sed -i -r "s/^(MONITORING_INTERNAL_PASSWORD=).*/\1'$MONITORING'/" .env
BEATS=$(docker exec -it elasticsearch bin/elasticsearch-reset-password --batch --user beats_system | grep New | cut -d ' ' -f 3 | sed -r "s/[\r\n]+//" -); sed -i -r "s/^(BEATS_SYSTEM_PASSWORD=).*/\1'$BEATS'/" .env

C_UUID=$(curl -s --location --request GET 'http://localhost:9200/' -u "elastic:$ELASTIC" | jq -r ".cluster_uuid"); sed -i -r "s/^(CLUSTER_UUID=).*/\1'$C_UUID'/" .env
```

</details>

Redémarer Logstash, Filebeat and Kibana pour se re-connecter à Elasticsearch avec ces mots de passe :
```bash
docker-compose up -d filebeat logstash kibana
```



NOTES
```yaml


- module: beat
  metricsets:
    - stats
    - state
  period: 10s
  hosts: ["http://filebeat:5066"]
```