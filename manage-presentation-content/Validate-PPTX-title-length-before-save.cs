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