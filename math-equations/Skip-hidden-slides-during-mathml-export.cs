// -----------------------------------------------------------------------------
// Example: Export Visible Slides Only from PowerPoint Using Aspose.Slides
//
// Description:
// This console application loads a PowerPoint PPTX file, iterates through its
// slides, and creates a new presentation that contains only the slides that are
// not hidden (ISlide.Hidden == false). It demonstrates how to filter out hidden
// slides during export using Aspose.Slides for .NET and saves the result as a
// PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, slide visibility, hidden slides, export
//
// Use Cases:
// - Generate a clean version of a presentation without hidden draft slides.
// - Prepare a shareable PPTX that excludes internal or placeholder content.
// - Automate slide filtering in a CI/CD pipeline for presentation assets.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesExportVisible
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output_visible.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.Presentation destinationPresentation = new Aspose.Slides.Presentation();

                for (int i = 0; i < sourcePresentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[i];

                    // Exclude hidden slides
                    if (sourceSlide.Hidden == false)
                    {
                        destinationPresentation.Slides.AddClone(sourceSlide);
                    }
                }

                destinationPresentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                sourcePresentation.Dispose();
                destinationPresentation.Dispose();

                Console.WriteLine("Export completed. Visible slides saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during processing: " + ex.Message);
            }
        }
    }
}
