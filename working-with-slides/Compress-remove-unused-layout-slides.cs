// -----------------------------------------------------------------------------
// Example: Compress PowerPoint by Removing Unused Layout Slides
//
// Description:
// Demonstrates how to reduce a PPTX file size by deleting a slide and cleaning
// up unused layout slides using Aspose.Slides for .NET. The program creates a
// sample presentation if the input file is missing, performs the cleanup, and
// saves the optimized result.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, compress, remove unused layout slides
//
// Use Cases:
// - Optimize large presentations before distribution.
// - Automate cleanup of generated PPTX files in CI pipelines.
// - Reduce file size for faster loading in PowerPoint viewers.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Ensure input file exists; create a simple presentation if missing
            if (!File.Exists(inputPath))
            {
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }

            try
            {
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Delete the first slide if present
                    if (pres.Slides.Count > 0)
                    {
                        Aspose.Slides.ISlide firstSlide = pres.Slides[0];
                        firstSlide.Remove();
                    }

                    // Remove unused layout slides to compress the file
                    pres.LayoutSlides.RemoveUnused();

                    // Save the optimized presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
                Environment.Exit(1);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }

            Environment.Exit(0);
        }
    }
}
