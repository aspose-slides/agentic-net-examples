using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Access document properties
                IDocumentProperties documentProperties = presentation.DocumentProperties;

                // Remove the custom property named "ReviewStatus"
                bool removed = documentProperties.RemoveCustomProperty("ReviewStatus");
                if (removed)
                {
                    Console.WriteLine("Custom property 'ReviewStatus' removed.");
                }
                else
                {
                    Console.WriteLine("Custom property 'ReviewStatus' not found.");
                }

                // Save the updated presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        // Handle unsupported format exceptions
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("Unsupported file format: " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("Unsupported file format: " + ex.Message);
        }
        // General exception handling
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}