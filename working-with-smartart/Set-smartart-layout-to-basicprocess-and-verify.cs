using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram with BasicBlockList layout
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

            // Change the layout to BasicProcess
            smartArt.Layout = SmartArtLayoutType.BasicProcess;

            // Verify that the layout has been changed
            if (smartArt.Layout == SmartArtLayoutType.BasicProcess)
            {
                Console.WriteLine("SmartArt layout successfully changed to BasicProcess.");
            }
            else
            {
                Console.WriteLine("Failed to change SmartArt layout.");
            }

            // Save the presentation
            string outputPath = "SmartArtLayoutChanged.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format, file I/O issues)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}