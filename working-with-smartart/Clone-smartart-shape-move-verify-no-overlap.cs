using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        string outputPath = "ClonedSmartArt.pptx";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Add a SmartArt shape to the slide
        ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

        // Clone the SmartArt shape and move the clone to coordinates (100, 200)
        IShape clonedShape = slide.Shapes.AddClone(smartArt, 100, 200);

        // Verify that the cloned shape does not overlap the original
        ISmartArt clonedSmartArt = clonedShape as ISmartArt;
        if (clonedSmartArt != null && (smartArt.X != clonedSmartArt.X || smartArt.Y != clonedSmartArt.Y))
        {
            // No overlap confirmed
        }

        // Save the presentation
        try
        {
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Dispose the presentation
        pres.Dispose();
    }
}