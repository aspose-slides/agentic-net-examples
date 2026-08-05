// -----------------------------------------------------------------------------
// Example: Compress remove orphaned master slides using C#
//
// Description:
// Demonstrates how to compress and remove orphaned master and layout slides
// from a PowerPoint presentation using C# and Aspose.Slides for .NET. The
// example loads a source PPTX, clones a slide with its master into a new
// presentation, then invokes the Compress utility to eliminate unused master
// and layout slides before saving the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Compress, Remove, Orphaned,
// Master Slides, Layout Slides, Presentation Processing, Office Automation
//
// Use Cases:
// - Reduce file size by eliminating unused master and layout slides.
// - Prepare clean presentations for distribution or archiving.
// - Automate PPTX cleanup in batch processing pipelines.
// - Integrate presentation optimization into .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Environment.CurrentDirectory, "source.pptx");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load source presentation
                using (Presentation srcPres = new Presentation(inputPath))
                {
                    // Create destination presentation
                    using (Presentation destPres = new Presentation())
                    {
                        // Clone first slide along with its master slide
                        ISlide sourceSlide = srcPres.Slides[0];
                        IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                        IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
                        destPres.Slides.AddClone(sourceSlide, destMaster, true);

                        // Remove unused master and layout slides from the destination presentation
                        Compress.RemoveUnusedMasterSlides(destPres);
                        Compress.RemoveUnusedLayoutSlides(destPres);

                        // Save the resulting presentation
                        destPres.Save(outputPath, SaveFormat.Pptx);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported
            }
        }
    }
}
