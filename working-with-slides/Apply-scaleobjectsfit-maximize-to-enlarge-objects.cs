// -----------------------------------------------------------------------------
// Example: Apply scaleobjectsfit maximize to enlarge objects using C#
//
// Description:
// Demonstrates how to increase a presentation's slide size and apply the
// ScaleObjectsFit.Maximize option to enlarge all objects so they fill the new
// slide dimensions using Aspose.Slides for .NET. The example loads an existing
// PPTX file, adjusts the slide size, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, ScaleObjectsFit, Maximize,
// Enlarge, Presentation Processing, Office Automation
//
// Use Cases:
// - Automatically enlarge slide content when changing slide dimensions.
// - Build C# utilities for scaling objects in PowerPoint presentations.
// - Integrate slide size adjustments into .NET automation workflows.
// - Validate visual layout after resizing slides in batch processing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
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
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Increase slide size and maximize objects to fill the new size
                presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize);

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // Comment: format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs or I/O errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
