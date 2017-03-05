# ScriptDatabase
Scripts a SQL server database using SMO from the command prompt.

# Credits

I take no credit for coming up with this. I found an awesome answer on [StackOverflow](http://stackoverflow.com/a/11655269) and just took the next logical step of putting it into an VS Solution.

# Options
The following script options are mapped to SSMS options:

- scrp.Options.AnsiPadding = false; // ANSI Padding
- scrp.Options.AppendToFile = false; // Append To File
- scrp.Options.IncludeIfNotExists = false; // Check for object existence
- scrp.Options.ContinueScriptingOnError = false; // Continue scripting on Error
- scrp.Options.ConvertUserDefinedDataTypesToBaseType = false; // Convert UDDTs to Base Types
- scrp.Options.WithDependencies = true; // Generate Scripts for Dependant Objects
- scrp.Options.IncludeHeaders = false; // Include Descriptive Headers
- scrp.Options.DriIncludeSystemNames = false; // Include system constraint names
- scrp.Options.Bindings = true; // Script Bindings
- scrp.Options.NoCollation = false; // Script Collation (Reverse of SSMS)
- scrp.Options.ScriptDrops = false; // Script DROP or Create (set to false to only script creates)
- scrp.Options.ExtendedProperties = true; // Script Extended Properties
- scrp.Options.LoginSid = false; // Script Logins
- scrp.Options.Permissions = false; // Script Object-Level Permissions
- scrp.Options.ScriptOwner = false; // Script Owner
- scrp.Options.Statistics = false; // Script Statistics
- scrp.Options.ScriptData = false; // Types of data to script (set to false for Schema Only)
- scrp.Options.ChangeTracking = false; // Script Change Tracking
- scrp.Options.ScriptDataCompression = false; // Script Data Compression Options
- scrp.Options.DriAll = true; // to include referential constraints in the script
- scrp.Options.FullTextIndexes = true; // Script Full-Text Indexes
- scrp.Options.Indexes = true;   // Script Indexes
- scrp.Options.Triggers = true; // Script Triggers
- scrp.Options.ScriptBatchTerminator = true; // ???
- scrp.PrefetchObjects = false; // Need to set to false otherwise primary keys will not be generated.

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
