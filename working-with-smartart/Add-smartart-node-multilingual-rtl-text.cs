using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Set default text language to Arabic for RTL rendering
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.DefaultTextLanguage = "ar-SA";

        // Create a new presentation with the load options
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(loadOptions);

        // Add SmartArt diagram
        Aspose.Slides.SmartArt.ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicCycle);

        // Set SmartArt to right-to-left
        smartArt.IsReversed = true;

        // Add a new node to SmartArt
        Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes.AddNode();

        // Set multilingual text (Arabic and English)
        node.TextFrame.Text = "مرحبا World";

        // Save the presentation
        presentation.Save("SmartArtMultilingual.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose presentation
        presentation.Dispose();
    }
}