// -----------------------------------------------------------------------------
// Example: Extract VBA module source and save bas using C#
//
// Description:
// Demonstrates how to extract the source code of a specific VBA module from a
// PowerPoint presentation and save it as a .bas file using Aspose.Slides for .NET.
// The example loads a PPTX file, checks for a VBA project, locates the requested
// module, writes its source to the output directory, and optionally saves a copy
// of the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, VBA, Extract, Module, Source, Save, .bas, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of VBA module source code from PPTX files.
// - Build tools that archive or analyze VBA macros in presentations.
// - Integrate VBA handling into .NET applications for compliance or migration.
// - Generate .bas files for further editing or version control.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        string srcFile = "input.pptx";
        // Directory where the extracted VBA module will be saved
        string outputDir = "output";
        // Name of the VBA module to extract
        string targetModuleName = "Module1";

        // Verify that the source file exists
        if (!File.Exists(srcFile))
        {
            Console.WriteLine("Source presentation file does not exist.");
            return;
        }

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(srcFile);

            // Check if the presentation contains a VBA project
            if (pres.VbaProject == null)
            {
                Console.WriteLine("Presentation does not contain a VBA project.");
            }
            else
            {
                // Locate the specified VBA module
                IVbaModule targetModule = null;
                foreach (IVbaModule module in pres.VbaProject.Modules)
                {
                    if (module.Name == targetModuleName)
                    {
                        targetModule = module;
                        break;
                    }
                }

                if (targetModule == null)
                {
                    Console.WriteLine("Specified VBA module not found.");
                }
                else
                {
                    // Extract the source code
                    string sourceCode = targetModule.SourceCode;

                    // Path for the .bas file
                    string outFile = Path.Combine(outputDir, targetModuleName + ".bas");

                    // Write the source code to the .bas file
                    File.WriteAllText(outFile, sourceCode);
                    Console.WriteLine("VBA module extracted to: " + outFile);
                }
            }

            // Save the presentation before exiting
            string savedFile = Path.Combine(outputDir, "saved.pptx");
            pres.Save(savedFile, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("An error occurred: " + ex.Message);
            // Format not supported
        }
    }
}
