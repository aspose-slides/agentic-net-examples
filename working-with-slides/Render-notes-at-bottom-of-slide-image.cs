// -----------------------------------------------------------------------------
// Example: Render notes at bottom of slide image using C#
//
// Description:
// Demonstrates how to render notes at the bottom of a slide image using C# and
// Aspose.Slides for .NET. The example loads a PPTX file, configures the notes
// layout to appear at the bottom (truncated if necessary), renders the first
// slide together with its notes to a PNG image, and saves both the image and
// the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Render, Notes, Bottom, Slide,
// Image, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate rendering of slide images with notes positioned at the bottom.
// - Build C# utilities for PowerPoint presentation processing and image export.
// - Generate visual assets that include slide content and speaker notes.
// - Validate presentation layouts before publishing or integration.
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
        string outputImagePath = "slide_with_notes.png";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                RenderingOptions renderingOpts = new RenderingOptions();
                NotesCommentsLayoutingOptions notesLayout = new NotesCommentsLayoutingOptions();
                notesLayout.NotesPosition = NotesPositions.BottomTruncated;
                renderingOpts.SlidesLayoutOptions = notesLayout;

                IImage slideImage = pres.Slides[0].GetImage(renderingOpts);
                slideImage.Save(outputImagePath, ImageFormat.Png);

                // Save the presentation before exiting
                string savedPresentationPath = "saved.pptx";
                pres.Save(savedPresentationPath, SaveFormat.Pptx);
            }
        }
        catch (PptxUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
