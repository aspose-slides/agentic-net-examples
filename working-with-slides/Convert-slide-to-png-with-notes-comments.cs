// -----------------------------------------------------------------------------
// Example: Convert slide to PNG with notes and comments using C#
//
// Description:
// Demonstrates how to convert each slide of a PowerPoint presentation to PNG
// images while rendering notes and comments. The example uses Aspose.Slides for
// .NET to load a PPTX file, configure rendering options to include notes at the
// bottom (truncated) and comments on the right, saves each slide as a PNG file,
// and finally saves a processed copy of the presentation.
//
// Keywords:
// C#, Aspose.Slides, PPTX, PNG, Slide conversion, Notes, Comments, RenderingOptions,
// Presentation processing, Office automation
//
// Use Cases:
// - Generate PNG images of slides that include speaker notes and slide comments.
// - Automate creation of visual assets from PowerPoint files for documentation.
// - Build .NET tools that need to export presentations with annotations.
// - Validate and transform PPTX files while preserving notes and comments.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertSlidesToPngWithNotesComments
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "PresentationNotesComments.pptx";
            string outputDir = "OutputImages";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Ensure output directory exists
                    if (!Directory.Exists(outputDir))
                    {
                        Directory.CreateDirectory(outputDir);
                    }

                    // Configure rendering options to include notes and comments
                    RenderingOptions renderingOptions = new RenderingOptions();
                    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
                    layoutOptions.NotesPosition = NotesPositions.BottomTruncated;
                    layoutOptions.CommentsPosition = CommentsPositions.Right;
                    renderingOptions.SlidesLayoutOptions = layoutOptions;

                    // Iterate through each slide and save as PNG
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        using (IImage slideImage = slide.GetImage(renderingOptions))
                        {
                            string outputPath = Path.Combine(outputDir, $"Slide_{i + 1}.png");
                            slideImage.Save(outputPath, ImageFormat.Png);
                        }
                    }

                    // Save the presentation (as required before exit)
                    presentation.Save("ProcessedPresentation.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., network issues if a URL was used)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
