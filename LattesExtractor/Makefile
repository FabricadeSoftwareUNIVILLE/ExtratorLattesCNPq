build:
	rm -rf bin
	rm -rf obj
	nuget install -OutputDirectory ../packages
	xbuild LattesExtractor.csproj /verbosity:minimal /property:Configuration=Release
