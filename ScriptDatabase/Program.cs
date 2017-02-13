/*
References Used
===============

Microsoft.SqlServer.ConnectionInfo		13.0.0.0
Microsoft.SqlServer.Management.Sdk.Sfc	13.0.0.0
Microsoft.SqlServer.Smo					13.0.0.0

Credits
=======

This work was based of of: http://stackoverflow.com/a/11655269

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;

namespace ScriptDatabase
{
    class Program
    {
        static void Main(string[] args)
        {

            // Usage
            if (args.Length == 0) {

                Console.WriteLine("Usage: ScriptDatabase.exe <database> <server> <username> <password> <OuputFile (optional)>");
                Environment.Exit(0);

            }

            var OutputFile = string.Format("{0}.sql", args[0]);

            // No output file
            if (args.Length == 5) {
                OutputFile = args[4];
            }


            Server srv = new Server();
            srv.ConnectionContext.LoginSecure = false;
            srv.ConnectionContext.ServerInstance = args[1];
            srv.ConnectionContext.Login = args[2];
            srv.ConnectionContext.Password = args[3];

            // Reference the database.  
            Database db = srv.Databases[args[0]];

            Scripter scrp = new Scripter(srv);

            // I tried to map these to options in the script generator in SSMS
            scrp.Options.AnsiPadding = false; // ANSI Padding
            scrp.Options.AppendToFile = false; // Append To File
            scrp.Options.IncludeIfNotExists = false; // Check for object existence
            scrp.Options.ContinueScriptingOnError = false; // Continue scripting on Error
            scrp.Options.ConvertUserDefinedDataTypesToBaseType = false; // Convert UDDTs to Base Types
            scrp.Options.WithDependencies = true; // Generate Scripts for Dependant Objects
            scrp.Options.IncludeHeaders = false; // Include Descriptive Headers
            scrp.Options.DriIncludeSystemNames = false; // Include system constraint names
            scrp.Options.Bindings = true; // Script Bindings
            scrp.Options.NoCollation = false; // Script Collation (Reverse of SSMS)
            scrp.Options.DriDefaults = true; // Script Defaults
            scrp.Options.ScriptDrops = false; // Script DROP or Create (set to false to only script creates)
            scrp.Options.ExtendedProperties = true; // Script Extended Properties
            scrp.Options.LoginSid = false; // Script Logins
            scrp.Options.Permissions = false; // Script Object-Level Permissions
            scrp.Options.ScriptOwner = false; // Script Owner
            scrp.Options.Statistics = false; // Script Statistics
            scrp.Options.ScriptData = false; // Types of data to script (set to false for Schema Only)
            scrp.Options.ChangeTracking = false; // Script Change Tracking
            scrp.Options.ScriptDataCompression = false; // Script Data Compression Options
            scrp.Options.DriAll = true; // to include referential constraints in the script
            scrp.Options.DriAllConstraints = true; // to include referential constraints in the script
            // scrp.Options.DriForeignKeys = true; // Script Foreign Keys
            // scrp.Options.DriChecks = true; Script Check Constraints
            scrp.Options.FullTextIndexes = true; // Script Full-Text Indexes
            scrp.Options.Indexes = true;   // Script Indexes
            scrp.Options.Triggers = true; // Script Triggers
            scrp.Options.ScriptBatchTerminator = true; // ???
            scrp.PrefetchObjects = true; // some sources suggest this may speed things up

            var urns = new List<Urn>();

            // Iterate through the tables in database and script each one
            Console.WriteLine("\n\n\n=== Scripting Tables ===");
            foreach (Table tb in db.Tables)
            {
                // check if the table is not a system table
                if (tb.IsSystemObject == false)
                {
                    Console.WriteLine(tb.Name);
                    urns.Add(tb.Urn);
                }
            }

            // Iterate through the views in database and script each one. Display the script.
            Console.WriteLine("\n\n\n=== Scripting Views ===");
            foreach (View view in db.Views)
            {
                // check if the view is not a system object
                if (view.IsSystemObject == false)
                {
                    Console.WriteLine(view.Name);
                    urns.Add(view.Urn);
                }
            }

            // Iterate through the stored procedures in database and script each one. Display the script.
            Console.WriteLine("\n\n\n=== Scripting Stored Procedure ===");
            foreach (StoredProcedure sp in db.StoredProcedures)
            {
                // check if the procedure is not a system object
                if (sp.IsSystemObject == false)
                {
                    Console.WriteLine(sp.Name);
                    urns.Add(sp.Urn);
                }
            }

            // Iterate through the user defined functions in database and script each one. Display the script.
            Console.WriteLine("\n\n\n=== Scripting User Defined Functions ===");
            foreach (UserDefinedFunction udf in db.UserDefinedFunctions)
            {
                // check if the procedure is not a system object
                if (udf.IsSystemObject == false)
                {
                    Console.WriteLine(udf.Name);
                    urns.Add(udf.Urn);
                }
            }

            StringBuilder builder = new StringBuilder();
            System.Collections.Specialized.StringCollection sc = scrp.Script(urns.ToArray());
            foreach (string st in sc)
            {
                // It seems each string is a sensible batch, and putting GO after it makes it work in tools like SSMS.
                // Wrapping each string in an 'exec' statement would work better if using SqlCommand to run the script.
                builder.AppendLine(st);
                builder.AppendLine("GO");
            }

            Console.WriteLine("\n\n\n=== Scripting Complete!!! ===");
            Console.WriteLine(string.Format("=== Writing to file: {0} ===", OutputFile));

            System.IO.File.WriteAllText(OutputFile, builder.ToString());

            Console.WriteLine(string.Format("=== File Written ===", OutputFile));
        }
    }
}
