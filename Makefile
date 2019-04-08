run-clean: cleanup restore build run 

all : cleanup restore build

cleanup:
	dotnet clean CookedRabbit/
	dotnet clean Send/
	dotnet clean Receive/
	dotnet clean TestCooked/

restore:
	dotnet restore CookedRabbit/
	dotnet restore Send/
	dotnet restore Receive/
	dotnet restore TestCooked/
	

build:
	dotnet build CookedRabbit/
	dotnet build Send/
	dotnet build Receive/
	dotnet build TestCooked/
	
run-send:
	dotnet run -p Send/Send.csproj
	
run-receive:
	dotnet run -p Receive/Receive.csproj
	
test:
	dotnet test