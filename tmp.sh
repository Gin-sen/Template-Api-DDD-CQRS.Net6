#!/bin/env bash


ELASTIC=$(docker exec -it elasticsearch bin/elasticsearch-reset-password --batch --user elastic | grep New | cut -d ' ' -f 3 | sed -r "s/[\r\n]+//" -); sed -i -r "s/^(ELASTIC_PASSWORD=).*/\1'$ELASTIC'/" .env
LOGSTASH_INTERNAL=$(docker exec -it elasticsearch bin/elasticsearch-reset-password --batch --user logstash_internal | grep New | cut -d ' ' -f 3 | sed -r "s/[\r\n]+//" -); sed -i -r "s/^(LOGSTASH_INTERNAL_PASSWORD=).*/\1'$LOGSTASH_INTERNAL'/" .env
KIBANA=$(docker exec -it elasticsearch bin/elasticsearch-reset-password --batch --user kibana_system | grep New | cut -d ' ' -f 3 | sed -r "s/[\r\n]+//" -); sed -i -r "s/^(KIBANA_SYSTEM_PASSWORD=).*/\1'$KIBANA'/" .env
FILEBEAT=$(docker exec -it elasticsearch bin/elasticsearch-reset-password --batch --user filebeat_internal | grep New | cut -d ' ' -f 3 | sed -r "s/[\r\n]+//" -); sed -i -r "s/^(FILEBEAT_INTERNAL_PASSWORD=).*/\1'$FILEBEAT'/" .env
METRICBEAT=$(docker exec -it elasticsearch bin/elasticsearch-reset-password --batch --user metricbeat_internal | grep New | cut -d ' ' -f 3 | sed -r "s/[\r\n]+//" -); sed -i -r "s/^(METRICBEAT_INTERNAL_PASSWORD=).*/\1'$METRICBEAT'/" .env
HEARTBEAT=$(docker exec -it elasticsearch bin/elasticsearch-reset-password --batch --user heartbeat_internal | grep New | cut -d ' ' -f 3 | sed -r "s/[\r\n]+//" -); sed -i -r "s/^(HEARTBEAT_INTERNAL_PASSWORD=).*/\1'$HEARTBEAT'/" .env
MONITORING=$(docker exec -it elasticsearch bin/elasticsearch-reset-password --batch --user monitoring_internal | grep New | cut -d ' ' -f 3 | sed -r "s/[\r\n]+//" -); sed -i -r "s/^(MONITORING_INTERNAL_PASSWORD=).*/\1'$MONITORING'/" .env
BEATS=$(docker exec -it elasticsearch bin/elasticsearch-reset-password --batch --user beats_system | grep New | cut -d ' ' -f 3 | sed -r "s/[\r\n]+//" -); sed -i -r "s/^(BEATS_SYSTEM_PASSWORD=).*/\1'$BEATS'/" .env

C_UUID=$(curl -s --location --request GET 'http://localhost:9200/' -u "elastic:$ELASTIC" | jq -r ".cluster_uuid"); sed -i -r "s/^(CLUSTER_UUID=).*/\1'$C_UUID'/" .env
