using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptm");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptm");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);

            // Validate that the VBA project contains at least one module
            if (presentation.VbaProject != null && presentation.VbaProject.Modules != null && presentation.VbaProject.Modules.Count > 0)
            {
                Console.WriteLine("VBA project contains modules. Proceeding with modifications.");
                // Example modification: add a new empty module
                presentation.VbaProject.Modules.AddEmptyModule("NewModule");
            }
            else
            {
                Console.WriteLine("VBA project does not contain any modules. No modifications performed.");
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, SaveFormat.Pptm);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}