using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram (Basic Cycle layout)
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicCycle);

        // Enable right-to-left rendering for RTL languages
        smartArt.IsReversed = true;

        // Add a new node to the SmartArt
        Aspose.Slides.SmartArt.ISmartArtNode newNode = smartArt.AllNodes.AddNode();

        // Set multilingual text (English and Arabic) on the node
        newNode.TextFrame.Text = "Hello, مرحبا";

        // Save the presentation
        try
        {
            presentation.Save("MultilingualSmartArt.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle format not supported or other save errors
        }
        finally
        {
            presentation.Dispose();
        }
    }
}