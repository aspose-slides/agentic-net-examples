// -----------------------------------------------------------------------------
// Example: Clone Layout Slide and Master to Another Presentation using C#
// 
// Description:
// Demonstrates how to clone a layout slide and its associated master slide from a source PPTX into a new presentation using Aspose.Slides for .NET. The program creates a sample source file if missing, performs the cloning, and saves the result.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Layout Slide, Clone Master Slide, Presentation Manipulation
// 
// Use Cases:
// - Reuse a slide layout and its master in another presentation.
// - Consolidate slides from multiple sources while preserving design.
// - Automate PPTX transformations that require master slide duplication.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;

class Program
{
    static void Main()
    {
        string sourcePath = "Source.pptx";
        string destinationPath = "Destination.pptx";

        try
        {
            // Create a simple source presentation if it does not exist
            if (!File.Exists(sourcePath))
            {
                using (Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation())
                {
                    Aspose.Slides.ISlide firstSlide = sourcePres.Slides[0];
                    Aspose.Slides.IShape shape = firstSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                    Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                    autoShape.AddTextFrame("Sample Slide");
                    sourcePres.Save(sourcePath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }

            // Load source presentation
            using (Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(sourcePath))
            {
                // Create destination presentation
                using (Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation())
                {
                    // Get the first slide from source
                    Aspose.Slides.ISlide sourceSlide = srcPres.Slides[0];

                    // Get the master slide associated with the source slide's layout
                    Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

                    // Clone the source master slide into the destination presentation
                    Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);

                    // Clone the source slide into the destination presentation using the cloned master
                    destPres.Slides.AddClone(sourceSlide, destMaster, true);

                    // Save the destination presentation
                    destPres.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }

            Console.WriteLine("Cloning completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
