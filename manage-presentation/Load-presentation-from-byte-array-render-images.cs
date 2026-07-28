// -----------------------------------------------------------------------------
// Example: Load presentation from byte array and render slide images using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation from a byte array,
// render each slide to a JPEG image, and save the presentation using
// Aspose.Slides for .NET. The example simulates receiving presentation data
// over a network stream, processes the slides, and outputs both image files
// and a saved PPTX file in a standalone console application. Developers can
// use this pattern to automate PPTX workflows, generate slide thumbnails,
// or integrate presentation handling into .NET services.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Presentation, Byte Array,
// Slide Rendering, Image Export, Office Automation
//
// Use Cases:
// - Load a presentation from a byte array received via network or API.
// - Generate JPEG thumbnails for each slide in a presentation.
// - Save processed presentations after manipulation.
// - Build .NET tools for automated PowerPoint processing and image extraction.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to a local file used to simulate receiving data over a network stream
        string sourcePath = "input.pptx";

        // Verify that the source file exists
        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file not found.");
            return;
        }

        // Read the presentation file into a byte array (simulating network data)
        byte[] presentationData = File.ReadAllBytes(sourcePath);

        // Load the presentation from the byte array
        IPresentation presentation;
        try
        {
            presentation = PresentationFactory.Instance.ReadPresentation(presentationData);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("Presentation format not supported.");
            return;
        }

        // Iterate through each slide and render it to an image
        for (int index = 0; index < presentation.Slides.Count; index++)
        {
            ISlide slide = presentation.Slides[index];
            // GetImage returns a thumbnail (20% of real size) by default
            IImage slideImage = slide.GetImage();
            string outputImagePath = $"slide_{index + 1}.jpg";
            slideImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Jpeg);
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}
