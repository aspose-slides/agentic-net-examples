using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtMultilingualExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set default text language to Arabic (right‑to‑left)
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DefaultTextLanguage = "ar-SA";

            // Create a new presentation with the specified load options
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(loadOptions);

            // Add a SmartArt diagram to the first slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
                10, 10, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicCycle);

            // Enable right‑to‑left rendering for the SmartArt
            smartArt.IsReversed = true;

            // Add a new node to the SmartArt and set multilingual text
            Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes.AddNode();
            node.TextFrame.Text = "Hello שלום مرحبا";

            // Save the presentation
            presentation.Save("SmartArtMultilingual.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}