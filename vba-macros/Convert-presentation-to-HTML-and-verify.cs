using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptm");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation while removing embedded binary objects (including VBA)
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.DeleteEmbeddedBinaryObjects = true;

            using (Presentation presentation = new Presentation(inputPath, loadOptions))
            {
                // Verify that no VBA code is present
                if (presentation.VbaProject != null && presentation.VbaProject.Modules.Count > 0)
                {
                    Console.WriteLine("VBA code still present after loading.");
                }
                else
                {
                    Console.WriteLine("No VBA code detected.");
                }

                // Convert to HTML
                presentation.Save(outputPath, SaveFormat.Html);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}