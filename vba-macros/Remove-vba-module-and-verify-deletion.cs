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
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}