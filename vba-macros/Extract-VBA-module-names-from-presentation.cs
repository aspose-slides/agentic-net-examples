// -----------------------------------------------------------------------------
// Example: Extract VBA module names from presentation using C#
//
// Description:
// Demonstrates how to extract VBA module names from a PowerPoint presentation
// using C# and Aspose.Slides for .NET. The example loads a PPTM file, checks
// for an embedded VBA project, enumerates its modules, and prints each module
// name to the console. It also saves the presentation back to PPTX format.
// Developers can use this pattern to automate VBA extraction, validate macro
// content, or integrate PowerPoint macro handling into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTM, PPTX, Aspose.Slides for .NET, VBA, Macro, Module, 
// Extraction, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of VBA module names from PowerPoint files.
// - Build C# tools for analyzing or documenting PowerPoint macros.
// - Integrate VBA inspection into .NET-based PowerPoint workflow pipelines.
// - Validate presence and names of VBA modules before publishing or further processing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Vba;
using Aspose.Slides.Export;

namespace ExtractVbaModules
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "sample.pptm";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found: " + filePath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(filePath))
                {
                    IVbaProject vbaProject = presentation.VbaProject;
                    if (vbaProject != null)
                    {
                        IVbaModuleCollection modules = vbaProject.Modules;
                        foreach (IVbaModule module in modules)
                        {
                            Console.WriteLine("Module: " + module.Name);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No VBA project found in the presentation.");
                    }

                    // Save the presentation before exiting
                    presentation.Save(filePath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
