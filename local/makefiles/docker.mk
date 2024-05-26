DB_CONTAINER_NAME = ${PROJECT_NAME}_database
DB_IMAGE_NAME = mongo
DB_IMAGE_VERSION = 7.0.8
DB_PORT = 27017

.PHONY: database-up
database-up:
	@echo "Starting database container: $(DB_CONTAINER_NAME)..."
	@docker run --detach --name $(DB_CONTAINER_NAME) -e MONGO_INITDB_ROOT_USERNAME=${DATABASE_USERNAME} -e MONGO_INITDB_ROOT_PASSWORD=${DATABASE_PASSWORD} -p $(DB_PORT):27017 $(DB_IMAGE_NAME):$(DB_IMAGE_VERSION)

.PHONY: database-down
database-down: database-stop database-remove

.PHONY: database-stop
database-stop:
	@echo "Stopping database container: $(DB_CONTAINER_NAME)..."
	@docker stop $(DB_CONTAINER_NAME)

.PHONY: database-remove
database-remove:
	@echo "Removing database container: $(DB_CONTAINER_NAME)..."
	@docker rm $(DB_CONTAINER_NAME)
