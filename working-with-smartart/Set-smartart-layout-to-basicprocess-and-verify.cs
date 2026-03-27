using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a SmartArt diagram with BasicBlockList layout
        Aspose.Slides.SmartArt.ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(0, 0, 400, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

        // Change the layout to BasicProcess
        smartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.BasicProcess;

        // Verify the layout change
        if (smartArt.Layout == Aspose.Slides.SmartArt.SmartArtLayoutType.BasicProcess)
        {
            Console.WriteLine("SmartArt layout successfully changed to BasicProcess.");
        }
        else
        {
            Console.WriteLine("Failed to change SmartArt layout.");
        }

        // Save the presentation
        presentation.Save("SmartArtLayoutChanged.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}