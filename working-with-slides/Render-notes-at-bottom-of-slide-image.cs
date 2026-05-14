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