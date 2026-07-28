// -----------------------------------------------------------------------------
// Example: Remove ReviewStatus custom property and save using C#
//
// Description:
// Demonstrates how to remove the "ReviewStatus" custom document property from a
// PowerPoint presentation and save the modified file using C# and Aspose.Slides
// for .NET. The example loads an existing PPTX, manipulates its document
// properties, and writes the result to a new file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, ReviewStatus, Custom Property,
// Document Properties, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of a specific custom property from presentations.
// - Build .NET tools for cleaning or updating PPTX metadata.
// - Integrate property management into PowerPoint workflow automation.
// - Ensure presentations meet compliance by stripping unwanted metadata.
// -----------------------------------------------------------------------------

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
