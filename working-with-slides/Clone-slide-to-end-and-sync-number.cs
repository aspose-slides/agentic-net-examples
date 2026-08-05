// -----------------------------------------------------------------------------
// Example: Clone slide to end and sync number using C#
//
// Description:
// Demonstrates how to clone the first slide (including its master) from a source
// presentation to a new presentation, place it at the end, and synchronize the
// slide numbering with the source using Aspose.Slides for .NET. The example
// includes file existence checks, error handling, and saves the result as a PPTX.
// This pattern can be used to programmatically duplicate slides while preserving
// layout and numbering.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Slide, Slide Master, Sync
// Slide Number, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of a specific slide to a new presentation.
// - Preserve slide master relationships during cloning.
// - Keep slide numbering consistent across source and destination.
// - Build .NET tools for PowerPoint slide manipulation and transformation.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputFile = "source.pptx";
        string outputFile = "cloned_output.pptx";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(inputFile))
            {
                using (Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation())
                {
                    // Clone slide with its master to the destination presentation
                    Aspose.Slides.ISlide sourceSlide = srcPres.Slides[0];
                    Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                    Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
                    destPres.Slides.AddClone(sourceSlide, destMaster, true);

                    // Synchronize slide number with source presentation
                    destPres.FirstSlideNumber = srcPres.FirstSlideNumber;

                    // Save the destination presentation
                    destPres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
                }
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
