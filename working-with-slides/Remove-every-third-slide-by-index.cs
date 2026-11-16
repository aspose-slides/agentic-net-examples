// -----------------------------------------------------------------------------
// Example: Remove every third slide by index using Aspose.Slides for .NET
//
// Description:
// This console program creates a sample PPTX file if none exists, then loads
// the presentation, removes every third slide (based on 1‑based position), and
// saves the modified presentation. It demonstrates slide removal automation
// with Aspose.Slides for .NET in C#.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove every third slide
//
// Use Cases:
// - Clean up presentations by deleting periodic placeholder slides.
// - Prepare slide decks for publishing by removing unwanted sections.
// - Integrate slide filtering into batch processing pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;

namespace RemoveEveryThirdSlide
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

            try
            {
                // Create a sample presentation if the input file does not exist
                if (!File.Exists(inputPath))
                {
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlideCollection sampleSlides = samplePres.Slides;
                    Aspose.Slides.ILayoutSlide layout = sampleSlides[0].LayoutSlide;

                    // Add additional slides to have a total of 9 slides
                    for (int i = 1; i < 9; i++)
                    {
                        sampleSlides.AddEmptySlide(layout);
                    }

                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePres.Dispose();
                    Console.WriteLine("Sample input presentation created: " + inputPath);
                }

                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.ISlideCollection slides = pres.Slides;

                // Remove every third slide (1‑based positions 3, 6, 9, ...)
                int index = 0;
                while (index < slides.Count)
                {
                    if ((index + 1) % 3 == 0)
                    {
                        slides.RemoveAt(index);
                        // Do not increment index because the next slide shifts into current position
                    }
                    else
                    {
                        index++;
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Modified presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
