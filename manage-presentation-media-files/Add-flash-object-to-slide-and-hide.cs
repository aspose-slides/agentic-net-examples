// -----------------------------------------------------------------------------
// Example: Add flash object to slide and hide using C#
//
// Description:
// Demonstrates how to add a flash (SWF) object to a slide and hide it during
// playback using C# and Aspose.Slides for .NET. The example creates a new
// presentation, inserts the flash file as a video frame placeholder, sets the
// HideAtShowing property, and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Flash, SWF, Object, Slide, Hide,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of flash objects into PowerPoint slides and hide them.
// - Build C# utilities for managing media objects in presentations.
// - Generate or modify PPTX files with embedded flash content in .NET apps.
// - Validate presentation media handling before deployment.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the flash (SWF) file to be added
        string inputPath = "flashObject.swf";
        // Path where the presentation will be saved
        string outputPath = "FlashObjectPresentation.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add the flash object as a video frame (placeholder for actual flash embedding)
            Aspose.Slides.IVideoFrame flashFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 200, inputPath);

            // Hide the flash object during playback
            flashFrame.HideAtShowing = true;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format or saving issues
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
