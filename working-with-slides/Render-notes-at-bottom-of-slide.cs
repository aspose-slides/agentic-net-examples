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
        string outputPresentationPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                // Configure rendering options to place notes at the bottom (truncated)
                RenderingOptions renderingOpts = new RenderingOptions();
                NotesCommentsLayoutingOptions notesLayout = new NotesCommentsLayoutingOptions();
                notesLayout.NotesPosition = NotesPositions.BottomTruncated;
                renderingOpts.SlidesLayoutOptions = notesLayout;

                // Render the first slide with notes
                IImage slideImage = pres.Slides[0].GetImage(renderingOpts);
                slideImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);

                // Save the presentation (even if unchanged)
                pres.Save(outputPresentationPath, SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}