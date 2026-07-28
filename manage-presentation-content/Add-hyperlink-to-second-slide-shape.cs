// -----------------------------------------------------------------------------
// Example: Add hyperlink to second slide shape using C#
//
// Description:
// Demonstrates how to add an external hyperlink to the first shape on the
// second slide of a PowerPoint presentation using C# and Aspose.Slides for .NET.
// The example loads an existing PPTX file, verifies the presence of a second
// slide and at least one shape, applies the hyperlink while preserving the
// shape's formatting, and saves the result as a new PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hyperlink, Second Slide, Shape,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding external hyperlinks to shapes on a specific slide.
// - Build C# utilities for PowerPoint presentation manipulation.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate and test hyperlink integration before publishing presentations.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        // URL to be set as hyperlink
        string url = "https://www.example.com";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Ensure the presentation has at least two slides
            if (presentation.Slides.Count < 2)
            {
                Console.WriteLine("The presentation does not contain a second slide.");
                presentation.Dispose();
                return;
            }

            // Get the second slide (index 1)
            Aspose.Slides.ISlide secondSlide = presentation.Slides[1];

            // Ensure there is at least one shape on the second slide
            if (secondSlide.Shapes.Count == 0)
            {
                Console.WriteLine("No shapes found on the second slide.");
                presentation.Dispose();
                return;
            }

            // Select the first shape on the second slide
            Aspose.Slides.IShape targetShape = secondSlide.Shapes[0];

            // Add external hyperlink to the shape while preserving existing formatting
            targetShape.HyperlinkManager.SetExternalHyperlinkClick(url);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported.
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., network issues for external URLs)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
