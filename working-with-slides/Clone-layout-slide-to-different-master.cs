// -----------------------------------------------------------------------------
// Example: Clone layout slide to different master using C#
//
// Description:
// Demonstrates how to clone a layout slide from a source presentation into a
// destination presentation while also cloning its master slide using
// Aspose.Slides for .NET. The example loads a source PPTX, copies the first
// slide's layout and associated master to a new presentation, and saves the
// result. This pattern is useful for reusing slide designs across separate
// presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, Layout Slide, Master Slide,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Reuse a slide layout and its master in another presentation.
// - Build tools that consolidate slides from multiple sources while preserving design.
// - Automate PPTX transformations that require master slide duplication.
// - Validate and test slide cloning workflows in .NET applications.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string sourcePath = "Source.pptx";
        string destinationPath = "Destination.pptx";

        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file does not exist.");
            return;
        }

        try
        {
            using (Presentation srcPres = new Presentation(sourcePath))
            {
                using (Presentation destPres = new Presentation())
                {
                    // Get the first slide from the source presentation
                    ISlide sourceSlide = srcPres.Slides[0];
                    // Get the master slide associated with the source slide's layout
                    IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                    // Clone the source master slide into the destination presentation
                    IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
                    // Clone the source slide into the destination presentation using the cloned master
                    destPres.Slides.AddClone(sourceSlide, destMaster, true);
                    // Save the destination presentation
                    destPres.Save(destinationPath, SaveFormat.Pptx);
                }
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
