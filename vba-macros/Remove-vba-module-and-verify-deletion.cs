// -----------------------------------------------------------------------------
// Example: Remove VBA module and verify deletion using C#
//
// Description:
// Demonstrates how to remove a specific VBA module from a PowerPoint presentation
// and verify that the module has been deleted using Aspose.Slides for .NET. The
// example loads a PPTX file, removes the designated module from the VBA project,
// saves the modified presentation, reloads it, and confirms the module is no
// longer present. This pattern can be used in automation scripts or tools that
// need to clean or validate VBA content in presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, VBA, Module, Remove, Verify, Deletion, Presentation Processing
//
// Use Cases:
// - Automate removal of unwanted VBA modules from PPTX files.
// - Validate that VBA macros have been stripped before distribution.
// - Integrate VBA cleanup into .NET based document processing pipelines.
// - Ensure compliance with security policies by verifying macro removal.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");
        // Name of the VBA module to remove
        string moduleNameToRemove = "Module1";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Check if a VBA project with modules exists
            if (presentation.VbaProject != null && presentation.VbaProject.Modules.Count > 0)
            {
                // Locate the module with the specified name
                Aspose.Slides.Vba.IVbaModule moduleToRemove = null;
                foreach (Aspose.Slides.Vba.IVbaModule module in presentation.VbaProject.Modules)
                {
                    if (module.Name == moduleNameToRemove)
                    {
                        moduleToRemove = module;
                        break;
                    }
                }

                // Remove the module if found
                if (moduleToRemove != null)
                {
                    presentation.VbaProject.Modules.Remove(moduleToRemove);
                    Console.WriteLine($"Module '{moduleNameToRemove}' removed.");
                }
                else
                {
                    Console.WriteLine($"Module '{moduleNameToRemove}' not found.");
                }
            }
            else
            {
                Console.WriteLine("No VBA project or modules found in the presentation.");
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();

            // Verify that the module has been removed
            Presentation verifyPresentation = new Presentation(outputPath);
            bool moduleExists = false;
            if (verifyPresentation.VbaProject != null)
            {
                foreach (var mod in verifyPresentation.VbaProject.Modules)
                {
                    if (mod.Name == moduleNameToRemove)
                    {
                        moduleExists = true;
                        break;
                    }
                }
            }

            Console.WriteLine(moduleExists
                ? $"Verification failed: Module '{moduleNameToRemove}' still exists."
                : $"Verification succeeded: Module '{moduleNameToRemove}' not found.");
            verifyPresentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
