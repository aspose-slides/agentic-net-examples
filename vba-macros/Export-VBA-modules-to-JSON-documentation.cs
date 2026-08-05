// -----------------------------------------------------------------------------
// Example: Export VBA modules to JSON documentation using C#
//
// Description:
// Demonstrates how to extract VBA macro modules from a PowerPoint presentation
// and export them as a JSON document using C# and Aspose.Slides for .NET. The
// example loads a PPTX file, reads each VBA module's name and source code, and
// serializes the collection to a formatted JSON file. This pattern can be used
// to document, analyze, or migrate VBA macros embedded in presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, VBA, Macro, Export, JSON,
// Documentation, Presentation Processing, Office Automation
//
// Use Cases:
// - Generate JSON documentation of VBA macros for review or auditing.
// - Build tools that extract and analyze VBA code from PowerPoint files.
// - Integrate VBA extraction into .NET applications or CI pipelines.
// - Facilitate migration of VBA macros to other platforms or languages.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

namespace AsposeSlidesVbaExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation file
            string inputPath = "input.pptx";
            // Output JSON documentation file
            string jsonOutputPath = "macros.json";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Ensure VBA project exists
                IVbaProject vbaProject = presentation.VbaProject;
                if (vbaProject == null)
                {
                    Console.WriteLine("No VBA project found in the presentation.");
                }
                else
                {
                    // Collect macro source code from all modules
                    List<Dictionary<string, string>> modulesInfo = new List<Dictionary<string, string>>();
                    for (int i = 0; i < vbaProject.Modules.Count; i++)
                    {
                        IVbaModule module = vbaProject.Modules[i];
                        Dictionary<string, string> moduleData = new Dictionary<string, string>();
                        moduleData["Name"] = module.Name;
                        moduleData["SourceCode"] = module.SourceCode ?? string.Empty;
                        modulesInfo.Add(moduleData);
                    }

                    // Serialize to JSON
                    string json = JsonSerializer.Serialize(modulesInfo, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(jsonOutputPath, json);
                    Console.WriteLine("Macro source code exported to: " + jsonOutputPath);
                }

                // Save presentation before exit (no changes made)
                presentation.Save(inputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL or web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
