# Runtime/Setup

### This application is targeted to a x64 Windows Build.

## The access 2007 runtime is required to communicate with the database:
https://www.microsoft.com/en-us/download/details.aspx?id=4438

However this is not needed (if you do not wish to use a DB), the application will use .csv storage if this is not available. (A regkey is checked)

### The application requires an active internet connection.

### NuGet packages such as the DI framework should simply run with the included .dll files.

### It is not expected that there will be any issues related to API keys. (API JSON Schema are also *expected* to be fine)

## If building from source within Viusual Studio

### An x64 platform must be targeted.

### The following NuGet Packages must be installed:
.....

Castle.Core

Microsoft.Azure.CognitiveServices.Language.TextAnalytics

Microsoft.Rest.ClientRuntime

Microsoft.Rest.ClientRuntime.Azure

Newtonsoft.Json

Ninject

Ninject.Extensions.Interception

Ninject.Extensions.Interception.DynamicProxy


.....
### The supplied App.Config file provided should be used, unless storage locations etc. are to be changed.

### As an alternative, clone the repository at https://github.com/Junaid-D/ELEN4010_DI

# Config

Some aspects of the domain can be mocked to use some pre-stored versions of API responses, though this is not required. The application can be run without altering configuration.

# Running

Running the .exe file will run the application; it completes without any input.
The general flow is to fetch stories (printout)-->store in persistent store-->retrieve from persistent store--->perform keyword analysis (printout)--->end

## Outputs

### Logging of API calls and some exceptions is done to a text file: log.txt
### Console printouts of results: Stories and keyword analysis.
### Data storage in persistent stores: test.csv and testDB.accdb
The database will require MS Access or an alternative to be viewed.
