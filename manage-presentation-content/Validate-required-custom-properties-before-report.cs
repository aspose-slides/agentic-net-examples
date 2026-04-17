using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation with exception handling for unsupported formats
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Format not supported
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Define required custom property names
        string[] requiredProperties = new string[] { "ReportId", "ReportDate" };

        // Access document properties
        Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

        // Validate that each required custom property exists
        foreach (string propertyName in requiredProperties)
        {
            bool exists = documentProperties.ContainsCustomProperty(propertyName);
            if (!exists)
            {
                Console.WriteLine("Required custom property missing: " + propertyName);
                presentation.Dispose();
                return;
            }
        }

        // All required properties are present; proceed with report generation
        Console.WriteLine("All required custom properties are present. Generating report...");

        // Save the presentation before exiting
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}