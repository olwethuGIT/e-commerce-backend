.ONESHELL:

.PHONY: install

COMPOSE_FILE ?= "./api/docker-compose.yml"

build:
	docker-compose -f $(COMPOSE_FILE) build

up:
	docker-compose -f $(COMPOSE_FILE) up -d --build

down:
	docker-compose -f $(COMPOSE_FILE) down

rebuild: down build up

restart:
	docker-compose -f $(COMPOSE_FILE) restart
	
web-shell:
	docker-compose -f $(COMPOSE_FILE) exec web bash
