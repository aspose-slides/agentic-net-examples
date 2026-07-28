// -----------------------------------------------------------------------------
// Example: Validate required custom properties before report using C#
//
// Description:
// Demonstrates how to validate required custom properties in a PowerPoint
// presentation before generating a report using C# and Aspose.Slides for .NET.
// The example loads a PPTX file, checks for the presence of specific custom
// document properties, and proceeds only if all required properties are found.
// It then saves the presentation, illustrating a typical validation step in
// automated PPTX workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Required, Custom,
// Properties, Presentation Processing, Office Automation
//
// Use Cases:
// - Ensure required custom properties exist before report generation.
// - Automate validation of PowerPoint metadata in .NET applications.
// - Integrate property checks into PPTX processing pipelines.
// - Prevent publishing of presentations missing essential metadata.
// -----------------------------------------------------------------------------

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
