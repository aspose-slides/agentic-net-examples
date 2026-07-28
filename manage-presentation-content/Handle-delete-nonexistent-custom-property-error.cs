// -----------------------------------------------------------------------------
// Example: Handle delete nonexistent custom property error using C#
//
// Description:
// Demonstrates how to handle delete nonexistent custom property error using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Handle, Delete, Nonexistent, 
// Custom, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate handle delete nonexistent custom property error.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input and output presentations
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation from the file
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the document properties collection
                Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

                // Name of the custom property to delete
                string propertyName = "NonExistentProperty";

                // Attempt to remove the custom property
                bool removed = docProps.RemoveCustomProperty(propertyName);
                if (removed)
                {
                    Console.WriteLine("Custom property removed: " + propertyName);
                }
                else
                {
                    Console.WriteLine("Custom property not found: " + propertyName);
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        // Handle unsupported PPTX format
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            Console.WriteLine("Unsupported PPTX format: " + ex.Message);
        }
        // Handle unsupported PPT format
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            Console.WriteLine("Unsupported PPT format: " + ex.Message);
        }
        // General exception handling
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
