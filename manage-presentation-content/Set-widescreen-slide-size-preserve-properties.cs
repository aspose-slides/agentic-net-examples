// -----------------------------------------------------------------------------
// Example: Set widescreen slide size preserve properties using C#
//
// Description:
// Demonstrates how to change a PowerPoint presentation to widescreen slide size
// while preserving existing content using Aspose.Slides for .NET. The example
// loads an existing PPTX file, applies the widescreen size with the EnsureFit
// scaling mode, and saves the result as a new PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Widescreen, Slide Size, Preserve, Presentation Processing, Office Automation
//
// Use Cases:
// - Convert presentations to widescreen format without losing layout.
// - Automate batch resizing of PPTX files in .NET applications.
// - Integrate slide size adjustments into custom PowerPoint processing tools.
// - Ensure content fits when changing slide dimensions programmatically.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Set slide size to widescreen format while preserving existing content
            presentation.SlideSize.SetSize(Aspose.Slides.SlideSizeType.Widescreen, Aspose.Slides.SlideSizeScaleType.EnsureFit);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
