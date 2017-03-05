# ScriptDatabase
Scripts a SQL server database using SMO from the command prompt.

# Credits

I take no credit for coming up with this. I found an awesome answer on [StackOverflow](http://stackoverflow.com/a/11655269) and just took the next logical step of putting it into an VS Solution.

# Options
The following script options are mapped to SSMS options:

- AnsiPadding = false; // ANSI Padding
- AppendToFile = false; // Append To File
- IncludeIfNotExists = false; // Check for object existence
- ContinueScriptingOnError = false; // Continue scripting on Error
- ConvertUserDefinedDataTypesToBaseType = false; // Convert UDDTs to Base Types
- WithDependencies = true; // Generate Scripts for Dependant Objects
- IncludeHeaders = false; // Include Descriptive Headers
- DriIncludeSystemNames = false; // Include system constraint names
- Bindings = true; // Script Bindings
- NoCollation = false; // Script Collation (Reverse of SSMS)
- DriDefaults = true; // Script Defaults
- ScriptDrops = false; // Script DROP or Create (set to false to only script creates)
- ExtendedProperties = true; // Script Extended Properties
- LoginSid = false; // Script Logins
- Permissions = false; // Script Object-Level Permissions
- ScriptOwner = false; // Script Owner
- Statistics = false; // Script Statistics
- ScriptData = false; // Types of data to script (set to false for Schema Only)
- ChangeTracking = false; // Script Change Tracking
- ScriptDataCompression = false; // Script Data Compression Options
- DriAll = true; // to include referential constraints in the script
- DriAllConstraints = true; // to include referential constraints in the script
- FullTextIndexes = true; // Script Full-Text Indexes
- Indexes = true;   // Script Indexes
- Triggers = true; // Script Triggers
- ScriptBatchTerminator = true; // ???
- PrefetchObjects = true; // some sources suggest this may speed things up

# Compiling

You need to have [Sql Server Management Studio](https://go.microsoft.com/fwlink/?LinkID=840946) to get the SMO libraries installed.

You will need [Visual Studio 2015 Community Edition](https://www.visualstudio.com/downloads/)

# Running

You need to have [Sql Server Management Studio](https://go.microsoft.com/fwlink/?LinkID=840946) to get the SMO libraries installed.

NOTE: You must have at least Microsoft SQL Server 11.0.6020.0 in order for CONSTRAINTS to be scripted properly. There is a bug in earlier versions that prevent this.

From the command line enter the following:

ScriptDatabase.exe AdventureWorks localhost myuser mypass

# Contributing

Just send me a pull request via Github :)
I welcome any and all ideas and suggestions.
