source_dir := ./
sources := $(shell find $(source_dir) -iname "*.cs")
.PHONY: build

all: build run

build: $(sources)
	export WINEDEBUG=-all
	dotnet build -r win-x64 --self-contained

run: build
	bin/Debug/net10.0-windows/win-x64/finals.exe

clean:
	rm -rf bin/*
