.PHONY: check
check:
	@echo "Checking code formatting..."
	@dotnet format --verify-no-changes --no-restore --verbosity detailed

.PHONY: format
format:
	@echo "Formatting code..."
	@dotnet format --no-restore --verbosity detailed
