# FitFileConverter

This is a utility tool written in C# to convert Fit files. It is capable of converting a Fit file to json and back without data loss (enabling changing sport, potentially multiplying cadence, etc. in json and convert it back to Fit file) and the included class libarary also supports the editing of the parsed fit data.

It includes a class library with public APIs (see related [README.md](src/FitFileConverter.ClassLibrary/README.md)) to the do conversion and parsing of a Fit file. Furthermore there is a consol application wrapper around the library.

This means that one may convert a Fit file to Json, manipulate this Json and then convert it back to Fit file. If the original Fit file contains "unknown" fit messages or fields, when converting from json the --from-fit option (please see more details on [usage](#usage-FitFileConverter-command-path-options)) is necessary to avoid data loss. Unknown messages and fields in a Json file are not included, unless the original Fit file is included (as argument of the --from-fit flag) due to the lack of necessary metadata for conversion. This is a limitation/design of the Fit SDK rather then this app.

## Installing
**Compiling**

1) Clone repository
2) Download FIT SDK from [here](https://developer.garmin.com/fit/download/)
3) Set the location of the Fit.dll in "FitFileConverter.ConsoleApp.csproj" file (e.g. to "path/to/fit-sdk/FitSDKRelease_21.60.00\cs\Fit.dll")
4) Open the workspace in VSCode and run publish task, which will create a single executable in the dist folder

## Usage: `FitFileConverter [COMMAND] PATH [OPTIONS...]`

### *Verbs*
Verb    | Description
--------|------------
convert | Json/Fit converter
setup   | Generate metadata for json to fit converter
help    | Display more information on a specific command.
version | Display version information.

### *Converter example*

Convert "file.json" using "file.fit": `FitFileConverter convert --from-fit file.fit file.json`

Create Fit file from "file.json" to path "random/path/new.fit": `FitFileConverter convert --output random/path/new.fit file.fit`

Option            | Description
------------------|------------
PATH (pos. 0)  | Required. Path to the file to be converted
-g, --from-fit | Path of the original Fit file for the edited json
-o, --output   | Set edited output path and name

### *Setup example*

Setup both types and profiles: `FitFileConverter setup`

Setup only types: `FitFileConverter setup --types`

Option         | Description
---------------|------------
-p, --profiles | Generate profiles metadata
-t, --types    | Generate types metadata