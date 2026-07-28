// -----------------------------------------------------------------------------
// Example: Validate PPTX title length before save using C#
//
// Description:
// Demonstrates how to validate and truncate a PowerPoint presentation's title
// property if it exceeds a specified length before saving the file using
// Aspose.Slides for .NET. The example loads an existing PPTX, checks the
// DocumentProperties.Title, trims it to a maximum of 100 characters when
// necessary, and then saves the updated presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Title, Length, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Ensure PPTX title metadata complies with length restrictions before distribution.
// - Automate validation of presentation properties in batch processing scripts.
// - Integrate title length checks into .NET applications that generate or modify PPTX files.
// - Prevent errors or warnings from downstream systems that enforce title length limits.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception)
        {
            // Format not supported or other loading error
            Console.WriteLine("Failed to load the presentation. The file format may not be supported.");
            return;
        }

        // Access document properties
        Aspose.Slides.IDocumentProperties properties = presentation.DocumentProperties;

        // Validate Title length (max 100 characters)
        string title = properties.Title;
        if (!string.IsNullOrEmpty(title) && title.Length > 100)
        {
            // Truncate the title to 100 characters
            properties.Title = title.Substring(0, 100);
        }

        // Save the presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle save errors (e.g., unsupported format)
            Console.WriteLine("Failed to save the presentation.");
        }
        finally
        {
            // Ensure resources are released
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}
