using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "PresentationNotesComments.pptx";
        string outputDir = "output";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                // Set rendering options to include notes and comments
                RenderingOptions renderingOpts = new RenderingOptions();
                NotesCommentsLayoutingOptions notesCommentsLayout = new NotesCommentsLayoutingOptions();
                notesCommentsLayout.NotesPosition = NotesPositions.BottomTruncated;
                notesCommentsLayout.CommentsPosition = CommentsPositions.Right;
                notesCommentsLayout.CommentsAreaWidth = 500;
                renderingOpts.SlidesLayoutOptions = notesCommentsLayout;

                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    ISlide slide = pres.Slides[i];
                    using (IImage image = slide.GetImage(renderingOpts, 2f, 2f))
                    {
                        string outPath = Path.Combine(outputDir, $"Slide_{i + 1}.png");
                        image.Save(outPath, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save the presentation before exiting
                pres.Save("ModifiedPresentation.pptx", SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}