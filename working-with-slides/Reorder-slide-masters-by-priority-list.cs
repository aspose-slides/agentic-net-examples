// -----------------------------------------------------------------------------
// Example: Reorder Slide Masters by Priority List Using Aspose.Slides
//
// Description:
// This console program creates a sample PowerPoint file if none exists, then
// reorders its slide masters according to a predefined priority list. It
// clones the masters and slides into a new presentation and saves the result.
// The task demonstrates automated master‑slide management with Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Reorder Slide Masters, Priority List
//
// Use Cases:
// - Standardize master slide ordering across corporate templates.
// - Build preprocessing tools that enforce master hierarchy before publishing.
// - Automate migration of presentations to a new master slide structure.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace SlideMasterReorder
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output_reordered.pptx";

            try
            {
                // Create a sample input presentation if it does not exist
                if (!File.Exists(inputPath))
                {
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();

                    // Ensure there are at least three master slides for demonstration
                    Aspose.Slides.IMasterSlide firstMaster = samplePres.Masters[0];
                    Aspose.Slides.IMasterSlide secondMaster = samplePres.Masters.AddClone(firstMaster);
                    Aspose.Slides.IMasterSlide thirdMaster = samplePres.Masters.AddClone(firstMaster);

                    // Add three slides, each using a different master slide
                    Aspose.Slides.ISlide slide1 = samplePres.Slides.AddEmptySlide(firstMaster.LayoutSlides[0]);
                    Aspose.Slides.ISlide slide2 = samplePres.Slides.AddEmptySlide(secondMaster.LayoutSlides[0]);
                    Aspose.Slides.ISlide slide3 = samplePres.Slides.AddEmptySlide(thirdMaster.LayoutSlides[0]);

                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePres.Dispose();
                }

                // Load source presentation
                Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation(inputPath);

                // Define priority order of master slide indices (e.g., third, first, second)
                int[] priority = new int[] { 2, 0, 1 };

                // Create destination presentation
                Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

                // Clone masters into destination according to priority
                foreach (int index in priority)
                {
                    if (index >= 0 && index < sourcePres.Masters.Count)
                    {
                        Aspose.Slides.IMasterSlide sourceMaster = sourcePres.Masters[index];
                        destPres.Masters.AddClone(sourceMaster);
                    }
                }

                // Clone all slides; masters will be linked automatically
                foreach (Aspose.Slides.ISlide slide in sourcePres.Slides)
                {
                    destPres.Slides.AddClone(slide);
                }

                // Save the reordered presentation
                destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Clean up
                sourcePres.Dispose();
                destPres.Dispose();

                Console.WriteLine("Reordered presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                // Exit with non‑zero code to indicate failure
                Environment.Exit(1);
            }
        }
    }
}
