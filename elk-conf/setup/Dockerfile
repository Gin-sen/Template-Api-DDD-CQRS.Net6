FROM docker.elastic.co/elasticsearch/elasticsearch:8.5.2

USER root

RUN set -eux; \
	mkdir /state; \
	chmod 0775 /state; \
	chown elasticsearch:root /state

USER elasticsearch:root

ENTRYPOINT ["/entrypoint.sh"]